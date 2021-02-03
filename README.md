# Covid App
Uma simples aplicação composta de Web API + GUI reativa para mostrar a média móvel de coronavírus no Brasil nas últimas semanas

## 🚀 Começando
Essas instruções permitirão que você obtenha uma cópia do projeto em operação na sua máquina local para fins de desenvolvimento e teste.

### 📋 Pré-requisitos
* [.NET Core 3.1](https://dotnet.microsoft.com/download) ou superior
* [NodeJS + NPM](https://nodejs.org/en/)
* [Git](https://git-scm.com/downloads)

### 🔧 Compilando e executando
Abra um terminal e clone este repositório em qualquer diretório da sua máquina utilizando o comando:
```
git clone https://github.com/herculesdev/covid-app.git
```
#### 1. Web API
Acesse a pasta com:
```
cd covid-app/CovidApp
```

Compile utilizando:
```
dotnet build
```

Em seguida rode o servidor:
```
dotnet run --project CovidApp.API
```
Um resultado parecido com este será exibido
```
info: Microsoft.Hosting.Lifetime[0]
      Now listening on: https://localhost:5001
info: Microsoft.Hosting.Lifetime[0]
      Now listening on: http://localhost:5000
info: Microsoft.Hosting.Lifetime[0]
      Application started. Press Ctrl+C to shut down.
info: Microsoft.Hosting.Lifetime[0]
      Hosting environment: Development
info: Microsoft.Hosting.Lifetime[0]
      Content root path: C:\covid-app\CovidApp\CovidApp.API
```
Após isto, a Web API estará em pleno funcionamento. Para testar utilize um dos links do item "Now listening On" e faça uma requisição do tipo "Get" para o endpoint:
https://localhost:5001/casos/media?de=2021-02-02&ate=2021-02-03

O resultado deve um Json com a média móvel dos casos e morte no período especificados no parâmetro "de" e "ate" tal como
```
{
    "casos": 9283418,
    "mortes": 226309
}
```

#### 2. Client (Frontend)
Acesse a pasta:
```
cd covid-app/CovidAppClient
```
Rode o servidor com
```
npm run serve
```
Algo semelhante será mostrado
```
 DONE  Compiled successfully in 1158ms                                                                          19:04:58
  App running at:
  - Local:   http://localhost:8080/
  - Network: http://192.168.0.110:8080/
  Note that the development build is not optimized.
  To create a production build, run npm run build.
```
Utilize o link do item "local" e acesse através do navegador para visualizar o client em funcionamento

![Imagem do client em loading](https://i.postimg.cc/NjKxbmjD/screenshot-loading.png)
![Imagem do client em exibindo os dados](https://i.postimg.cc/CLYtvv3N/screenshot-resultado.png)

## 🛠️ Construído com
Ferramentas/tecnologias utilizadas para construção deste projeto

* [.NET Core](https://dotnet.microsoft.com/download) - Backend e Web API
* [Entity Framework Core](https://docs.microsoft.com/pt-br/ef/core/) - Mapeamento Objeto-Relacional
* [SQLite](https://www.sqlite.org/index.html) - Banco de Dados
* [VueJS](https://vuejs.org/) - Lib Javascript (Frontend)
* [Axios](https://github.com/axios/axios) - Cliente HTTP para JavaScript
* [Bootstrap](https://getbootstrap.com/s) - Framework CSS
* [Visual Studio Code](https://code.visualstudio.com/) - Editor de Código
