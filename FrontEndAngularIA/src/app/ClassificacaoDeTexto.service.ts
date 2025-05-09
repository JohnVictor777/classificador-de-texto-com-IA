import { inject, Injectable } from '@angular/core';
import { environment } from '../environments/environment.development';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ClassificacaoDeTextoService {
  constructor() {}
  private http = inject(HttpClient);
  
classificarTexto(texto: string) {
    return this.http.post<any>(`${environment.apiUrl}/api/Classificacao/classificar`, { Texto: texto });
}

}
  