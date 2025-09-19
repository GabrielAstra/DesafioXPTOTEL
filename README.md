DesafioXPTOTEL
Desafio ShowMeTheCode.

#Autenticação
Apenas com geração do token. Para usar com o Swagger vai precisar rodar a aplicação, clicar em "Authorize", no campo 'Value' vai colocar Bearer + O TOKEN.

#Testes
Para rodar os testes é coisa simples também, no Console dos Pacotes selecionar o projeto de testes e escrever "dotnet test", ou também por qualquer terminal dentro do caminho do projeto e escrever o mesmo script.

#CQRS
Utilizei os padrões CQRS na camada de Aplicação, mas confesso que não utilizei isso em minhas experiências profissionais, apenas projetos externos mesmo.

!IMPORTANTE!

A aplicação roda em memória, descartando o uso de ORM, me baseei em interfaces e repositórios. Achei mais fácil e rápido como solução.

Credenciais Padrão
Usuário que deixei padrão ao iniciar a aplicação:

ema: admin@teste.com
senha: 123456

email: cliente@teste.com 
senha: 123456

Pode usar para testes no login inicial. Lembrando que ao retornar o token no login, caso queira testar pelo Swagger precisará fazer o que eu falei na #Autenticação.

Teve partes que copiei e colei de sites, como a configuração da autenticação no Swagger que peguei do site Macoratti, pois isso não infere no pensamento da lógica.
