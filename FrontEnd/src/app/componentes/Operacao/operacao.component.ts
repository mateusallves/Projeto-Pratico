import { Component, OnInit } from "@angular/core";
import { OperacaoService } from "./operacao.service";

@Component({
    standalone:false,
    selector: 'operacao-componente',
    templateUrl: './operacao.componente.html'
})

export class OperacaoComponent implements OnInit{
    dados: any[] = [];
    novaOperacao: any = {descricao: ''};
    editarOperacao: any = null;

    constructor(private service: OperacaoService){}

    ngOnInit(): void {
        this.getTodos();
    }
    
    getTodos(){
        this.service.getTodos().subscribe({
            next: (data) => this.dados = data,
            error: (error) => {
                console.error('Erro ao carregar operações:', error);
                alert('Erro ao carregar lista de operações.');
            }
        });
    }
    
    adicionar(){
        if(!this.novaOperacao.descricao || !this.novaOperacao.descricao.trim()){return;}
        const dadosParaEnviar = { descricao: this.novaOperacao.descricao.trim() };
        this.service.criar(dadosParaEnviar).subscribe({
            next: () => {
                this.getTodos();
                this.novaOperacao = {descricao: ''};
            },
            error: (error) => {
                console.error('Erro ao criar operação:', error);
                alert('Erro ao criar operação. Verifique os dados e tente novamente.');
            }
        });
    }
    
    selecionarParaEdicao(item: any){
        this.editarOperacao = {...item};
    }
    
    salvarEdicao(){
        if(!this.editarOperacao.descricao || !this.editarOperacao.descricao.trim()){return;}
        const dadosParaEnviar = {
            ...this.editarOperacao,
            descricao: this.editarOperacao.descricao.trim(),
            cod_Operacao: this.editarOperacao.cod_Operacao
        };
        this.service.atualizar(dadosParaEnviar).subscribe({
            next: () => {
                this.editarOperacao = null;
                this.getTodos();
            },
            error: (error) => {
                console.error('Erro ao atualizar operação:', error);
                alert('Erro ao atualizar operação. Verifique os dados e tente novamente.');
            }
        });
    }
    
    cancelarEdicao(){
        this.editarOperacao = null;
    }
    
    deletar(id: number){
        if (!id) {
            alert('ID inválido para deletar. Tente novamente.');
            return;
        }
        if(confirm('Tem certeza que deseja deletar esta operação?')){
            this.service.deletar(id).subscribe({
                next: () => {
                    this.getTodos();
                },
                error: (error) => {
                    console.error('Erro ao deletar operação:', error);
                    alert('Erro ao deletar operação. Tente novamente.');
                }
            });
        }       
    }
}
