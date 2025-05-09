import { Component, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterOutlet } from '@angular/router';
import { ClassificacaoDeTextoService } from './ClassificacaoDeTexto.service';
import { environment } from '../environments/environment.development';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  carregando = false;
  resultado: string | null = null;
  erro: string | null = null;

  constructor(private classificacaoService: ClassificacaoDeTextoService) {}

  classificarTexto(texto: string) {
    if (!texto.trim()) {
      this.erro = 'Digite algum texto para classificar.';
      this.resultado = null;
      return;
    }

    this.carregando = true;
    this.erro = null;
    this.resultado = null;

    this.classificacaoService.classificarTexto(texto).subscribe({
      next: (res) => {
        this.resultado = this.interpretarResposta(res);
        this.carregando = false;
      },
      error: (err) => {
        this.erro = 'Erro ao classificar o texto. Tente novamente mais tarde.';
        console.error(err);
        this.carregando = false;
      }
    });
  }

  private interpretarResposta(resposta: any): string {
    return resposta.classificacao ?? 'Neutro';
  }
}