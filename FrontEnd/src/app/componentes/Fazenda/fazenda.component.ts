import { Component, OnInit } from '@angular/core';
import { FazendaService } from './fazenda.service';

@Component({
  standalone: false,
  selector: 'fazenda-componente',
  templateUrl: './fazenda.component.html'
})
export class FazendaComponent implements OnInit {
  dados: any[] = [];
  novaFazenda: any = { nome: '', area_HA: '' };
  editarFazenda: any = null;

  constructor(private service: FazendaService) {}

  ngOnInit(): void {
    this.getTodos();
    this.testarConectividade();
  }
  
  testarConectividade() {
    console.log('Testando conectividade com o backend de fazendas...');
    this.service.getTodos().subscribe({
      next: (data) => {
        console.log('✅ Conectividade OK - Dados recebidos:', data);
        if (data && data.length > 0) {
          console.log('Exemplo de estrutura de dados:', data[0]);
        }
      },
      error: (error) => {
        console.error('❌ Erro de conectividade:', error);
        console.error('Status:', error.status);
        console.error('Message:', error.message);
        console.error('URL:', error.url);
      }
    });
  }

  getTodos() {
    this.service.getTodos().subscribe({
      next: (data) => {
        this.dados = data;
        console.log('Dados recebidos:', data); // DEBUG
      },
      error: (error) => {
        console.error('Erro ao carregar fazendas:', error);
        alert('Erro ao carregar lista de fazendas.');
      }
    });
  }

  adicionar() {
    if (!this.novaFazenda.nome || !this.novaFazenda.nome.trim()) return;
    if (!this.novaFazenda.area_HA || parseFloat(this.novaFazenda.area_HA) <= 0) return;

    const dadosParaEnviar = {
      nome: this.novaFazenda.nome.trim(),
      area_HA: this.novaFazenda.area_HA.toString() // Enviar como string
    };

    this.service.criar(dadosParaEnviar).subscribe({
      next: () => {
        this.getTodos();
        this.novaFazenda = { nome: '', area_HA: '' };
      },
      error: (error) => {
        console.error('Erro ao criar fazenda:', error);
        alert('Erro ao criar fazenda. Verifique os dados e tente novamente.');
      }
    });
  }

  selecionarParaEdicao(item: any) {
    this.editarFazenda = { ...item };
  }

  salvarEdicao() {
    if (!this.editarFazenda.nome || !this.editarFazenda.nome.trim()) return;
    if (!this.editarFazenda.area_HA || parseFloat(this.editarFazenda.area_HA) <= 0) return;

    const dadosParaEnviar = {
      ...this.editarFazenda,
      nome: this.editarFazenda.nome.trim(),
      area_HA: this.editarFazenda.area_HA.toString() // Enviar como string
    };

    this.service.atualizar(dadosParaEnviar).subscribe({
      next: () => {
        this.editarFazenda = null;
        this.getTodos();
      },
      error: (error) => {
        console.error('Erro ao atualizar fazenda:', error);
        alert('Erro ao atualizar fazenda. Verifique os dados e tente novamente.');
      }
    });
  }

  cancelarEdicao() {
    this.editarFazenda = null;
  }

  deletar(id: number) {
    if (!id) {
      alert('ID inválido para deletar.');
      return;
    }
    if (confirm('Tem certeza que deseja excluir?')) {
      this.service.deletar(id).subscribe({
        next: () => this.getTodos(),
        error: (error) => {
          console.error('Erro ao deletar fazenda:', error);
          alert('Erro ao deletar fazenda. Tente novamente.');
        }
      });
    }
  }
}
