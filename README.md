# 🧠 Classificador de Texto com IA | ASP.NET + Angular + ML.NET

Este é um projeto completo de portfólio que integra **inteligência artificial** com **classificação de textos**, desenvolvido com:

- 🔷 ASP.NET Core (Web API)
- 🧠 ML.NET (IA para classificar texto)
- 📦 Entity Framework Core (banco de dados relacional)
- 🧩 Angular (interface front-end)

---

## 🎯 Objetivo

Permitir que o usuário insira um texto e receba uma **classificação automática (positivo, negativo, neutro)**.  
Todos os textos e classificações são **salvos no banco de dados** para histórico e análise futura.

---

## 🧪 Funcionalidades

- [x] Treinamento de IA com ML.NET
- [x] Classificação automática de texto
- [x] Integração com API em ASP.NET Core
- [x] Salvamento dos resultados no banco de dados (EF Core)
- [x] Interface moderna em Angular para enviar texto e visualizar histórico
- [x] Projeto modular e bem estruturado

---

## 🛠️ Tecnologias Usadas

| Camada        | Tecnologia             |
|---------------|------------------------|
| Backend       | ASP.NET Core Web API   |
| IA            | ML.NET                 |
| Banco de dados| Entity Framework Core + SQL Server |
| Frontend      | Angular                |
| Treinamento   | CSV simples (modelo supervisionado) |

---

## 📁 Estrutura do Projeto

```
/ClassificadorDeTextoComIA
├── TreinamentoML/        -> Treinamento e modelo IA
├── ApiClassificador/     -> Web API com ASP.NET Core + EF Core
├── FrontEndAngularIA/    -> Aplicação Angular
└── README.md             -> Este arquivo
```

---

## 🚀 Como Rodar

### 1. API ASP.NET Core

```bash
cd ApiClassificador
dotnet run
```

### 2. Angular

```bash
cd FrontEndAngularIA
npm install
ng serve
```

---

## 👨‍💻 Autor

**John Victor do E. Santo da Encarnação**

- 🌐 Site: [kaofetech.com](https://kaofetech.com)  
- 📂 Instagram: [johnvic7or](https://www.instagram.com/johnvic7or/)  
- ✉️ E-mail: victorjohn609@gmail.com  

---

> Projeto desenvolvido como parte de estudos e demonstração de habilidades com C#, Angular, Inteligência Artificial e desenvolvimento fullstack.
