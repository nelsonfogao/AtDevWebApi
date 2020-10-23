# Trabalho Final(At) - Desenvolvimento de Aplicações Web ASP .NET MVC e Web API

Nesse Assessment, você deve criar com o Visual Studio, uma solução com um projeto do tipo ASP.NET Web Application (.NET Framework). 
Essa aplicação deve ser tanto do tipo MVC quanto do tipo Web API e deve permitir que funcionários de uma editora gerenciem os livros e os autores dessa editora.<br />

Essa aplicação consiste em:<br />

Uma página para o cadastro de um livro.<br />
Uma página para a edição de um livro.<br />
Uma página de detalhes de um livro.<br />
Uma página para a deleção de um livro.<br />
Uma página que exibe a lista de livros.<br />
Uma página de cadastro de um autor.<br />
Uma página de edição de um autor.<br />
Uma página de detalhes de um autor.<br />
Uma página para a deleção de um autor.<br />
Uma página que exibe a lista de autores.<br />
Essa editora espera poder criar um aplicativo mobile em breve, portanto, é importante que todas essas funcionalidades também estejam disponíveis através de um serviço Web API.<br />

Esse serviço consiste em:<br />

Um método GET para a busca de uma lista de livros.<br />
Um método GET para a busca de um livro.<br />
Um método POST para a inclusão de um livro.<br />
Um método PUT para a atualização de um livro.<br />
Um método DELETE para a deleção de um livro.<br />
Um método GET para a busca de uma lista de autores.<br />
Um método GET para a busca de um autor.<br />
Um método POST para a criação de um autor.<br />
Um método PUT para a atualização de um autor.<br />
Um método DELETE para a deleção de um autor.<br />
Os livros devem conter os campos id, título, ISBN e ano, além da sua lista de autores.<br />

Os autores devem conter os campos id, nome, sobrenome, email e data de nascimento, além da sua lista de livros.<br />

É no cadastro de um livro que a relação do livro com os autores é estabelecida. No cadastro de um autor não é atribuído livros a ele.<br />

Essa aplicação web deve permitir que apenas usuários autenticados e autorizados realizem essas operações.<br />

É importante destacar que você deverá criar, no banco de dados, as tabelas Livro e Autor, seus relacionamentos, os modelos na aplicação, as visões fortemente tipadas, os controladores e as validações necessárias.<br />

Você deve utilizar o Entity Framework e pode escolher o modelo que preferir: Data First, Model First ou Code First. O acesso ao banco de dados deve ser colocado em uma biblioteca.<br />

O aluno deve colocar a lógica das operações, que seriam comuns aos controladores, tanto do MVC quanto do Web API, em uma outra biblioteca, para que não haja repetição de código.<br />
