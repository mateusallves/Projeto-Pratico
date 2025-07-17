import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";

@Injectable({providedIn: 'root'})

export class OperacaoService{
    private apiUrl = 'http://localhost:5093/api/operacoes';
    constructor(private http: HttpClient){}

    getTodos(){
        return this.http.get<any[]>(this.apiUrl);
    }
    criar(dados:any){
        return this.http.post<any>(this.apiUrl, dados);

    }
    atualizar(dados:any){
        return this.http.put<any>(`${this.apiUrl}/${dados.cod_Operacao}`, dados);
    }
    deletar(id:number){
        return this.http.delete<any>(`${this.apiUrl}/${id}`);
    }

}