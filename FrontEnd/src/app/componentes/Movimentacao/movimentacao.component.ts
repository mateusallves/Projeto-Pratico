import { Component, OnInit } from "@angular/core";
import { MovimentacaoService } from "./movimentacao.service";

@Component({
    standalone:false,
    selector: 'movimentacao-componente',
    templateUrl: './movimentacao.component.html'
})

export class MovimentacaoComponente implements OnInit{
    dados: any[] = [];
    novoMovimentacao: any = {data: '', cod_Operacao: 0, cod_Produtor:0, cod_Fazenda:0};
    editarMovimentacao: any = null;

    constructor(private service: MovimentacaoService){}

    ngOnInit(): void {
        this.getTodos();
    }
    
    getTodos() {
        this.service.getTodos().subscribe({
            next: (data) => {
                this.dados = data;
            },
            error: (error) => {
                alert('Erro ao carregar lista de movimentações.');
            }
        });
    }
    
    adicionar() {
        if (!this.novoMovimentacao.data || !this.novoMovimentacao.data.trim()) {
            alert('Data é obrigatória');
            return;
        }
        
        if (!this.novoMovimentacao.cod_Operacao) {
            alert('Operação é obrigatória');
            return;
        }
        
        if (!this.novoMovimentacao.cod_Produtor) {
            alert('Produtor é obrigatório');
            return;
        }
        
        if (!this.novoMovimentacao.cod_Fazenda) {
            alert('Fazenda é obrigatória');
            return;
        }
    
        const dadosParaEnviar = {
            data: this.formatarData(this.novoMovimentacao.data),
            cod_Operacao: Number(this.novoMovimentacao.cod_Operacao),
            cod_Produtor: Number(this.novoMovimentacao.cod_Produtor),
            cod_Fazenda: Number(this.novoMovimentacao.cod_Fazenda)
        };
    
        this.service.criar(dadosParaEnviar).subscribe({
            next: () => {
                this.getTodos();
                this.novoMovimentacao = {data: '', cod_Operacao: 0, cod_Produtor:0, cod_Fazenda:0};
            },
            error: (error) => {
                alert('Erro ao criar movimentação. Verifique os dados e tente novamente.');
            }
        });
    }
    
    private formatarData(dataString: string): string {
        if (!dataString) return '';
        
        if (dataString.match(/^\d{4}-\d{2}-\d{2}$/)) {
            return dataString;
        }
        
        const data = new Date(dataString);
        if (!isNaN(data.getTime())) {
            const ano = data.getFullYear();
            const mes = String(data.getMonth() + 1).padStart(2, '0');
            const dia = String(data.getDate()).padStart(2, '0');
            return `${ano}-${mes}-${dia}`;
        }
        
        return dataString;
    }
    
    selecionarParaEdicao(item: any) {
        this.editarMovimentacao = { ...item };
    }
    
    salvarEdicao() {
        if (!this.editarMovimentacao.data || !this.editarMovimentacao.data.trim() || 
            !this.editarMovimentacao.cod_Operacao || 
            !this.editarMovimentacao.cod_Produtor || 
            !this.editarMovimentacao.cod_Fazenda) return;
            
        const dadosParaEnviar = {
            ...this.editarMovimentacao,
            data: this.formatarData(this.editarMovimentacao.data),
            cod_Operacao: Number(this.editarMovimentacao.cod_Operacao),
            cod_Produtor: Number(this.editarMovimentacao.cod_Produtor),
            cod_Fazenda: Number(this.editarMovimentacao.cod_Fazenda)
        };
            
        this.service.atualizar(dadosParaEnviar).subscribe({
            next: () => {
                this.editarMovimentacao = null;
                this.getTodos();
            },
            error: (error) => {
                alert('Erro ao atualizar movimentação. Verifique os dados e tente novamente.');
            }
        });
    }
    
    cancelarEdicao() {
        this.editarMovimentacao = null;
    }
    
    deletar(id: number) {
        if (!id) {
            alert('ID inválido para deletar. Tente novamente.');
            return;
        }
        
        if (confirm('Tem certeza que deseja excluir?')) {
            this.service.deletar(id).subscribe({
                next: () => this.getTodos(),
                error: (error) => {
                    alert('Erro ao deletar movimentação. Tente novamente.');
                }
            });
        }
    }
}

