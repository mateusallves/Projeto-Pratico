import { Component, OnInit } from "@angular/core";
import { ProdutorService } from "./produtor.service";

@Component({
    standalone:false,
    selector: 'produtor-componente',
    templateUrl: './produtor.component.html'
})

export class ProdutorComponente implements OnInit{
    dados : any[] = [];
    novoProdutor: any = {nome: ''};
    editarProdutor: any = null;

    constructor(private service: ProdutorService){}
    ngOnInit(){
        this.getTodos();
        this.testarConectividade();
    }
    getTodos(){
        this.service.getTodos().subscribe({
            next: (data) => this.dados = data,
            error: (error) => {
                console.error('Erro ao carregar produtores:', error);
                alert('Erro ao carregar lista de produtores.');
            }
        });
    }
    adicionar(){
        if(!this.novoProdutor.nome || !this.novoProdutor.nome.trim()){return;}
        const dadosParaEnviar = { nome: this.novoProdutor.nome.trim() };
        this.service.criar(dadosParaEnviar).subscribe({
            next: () => {
                this.getTodos();
                this.novoProdutor = {nome: ''};
            },
            error: (error) => {
                console.error('Erro ao criar produtor:', error);
                alert('Erro ao criar produtor. Verifique os dados e tente novamente.');
            }
        });
    }
    selecionarParaEdicao(item: any){
        this.editarProdutor = {...item};
    }
    salvarEdicao(){
        if(!this.editarProdutor.nome || !this.editarProdutor.nome.trim()){return;}
        const dadosParaEnviar = {
            ...this.editarProdutor,
            nome: this.editarProdutor.nome.trim(),
            cod_Produtor: this.editarProdutor.cod_Produtor
        };
        this.service.atualizar(dadosParaEnviar).subscribe({
            next: () => {
                this.editarProdutor = null;
                this.getTodos();
            },
            error: (error) => {
                console.error('Erro ao atualizar produtor:', error);
                alert('Erro ao atualizar produtor. Verifique os dados e tente novamente.');
            }
        });
    }
    cancelarEdicao(){
        this.editarProdutor = null;
    }
    deletar(id: number){
        if (!id) {
            alert('ID inválido para deletar. Tente novamente.');
            return;
        }
        if(confirm('Tem certeza que deseja deletar este produtor?')){
            this.service.deletar(id).subscribe({
                next: () => {
                    this.getTodos();
                    alert('Produtor deletado com sucesso!');
                },
                error: (error) => {
                    console.error('Erro ao deletar produtor:', error);
                    alert('Erro ao deletar produtor. Tente novamente.');
                }
            });
        }       
    }
    testarConectividade() {
        console.log('Testando conectividade com o backend...');
        this.service.getTodos().subscribe({
            next: (data) => {
                console.log('✅ Conectividade OK - Dados recebidos:', data);
            },
            error: (error) => {
                console.error('❌ Erro de conectividade:', error);
                console.error('Status:', error.status);
                console.error('Message:', error.message);
                console.error('URL:', error.url);
            }
        });
    }
}
