
# Desenvolvimento da Aplicação

## Modelagem da Aplicação
[Descreva a modelagem da aplicação, incluindo a estrutura de dados, diagramas de classes ou entidades, e outras representações visuais relevantes.]

Avaliação e Comentários: 

- O diagrama de classes contém x

- A estrututura é x


## Tecnologias Utilizadas
### Backend 
- C# 
- API do spotify (para popular nossos dados)
- MySQL


## Programação de Funcionalidades
### Requisitos Atendidos
#### Requisitos Funcionais
|ID    | Descrição do Requisito  | Responsável | Artefato Criado | Estruturas de Dados | Teste/API | Atendido |
|------|-----------------------------------------|----|----|----|----|----|
|RF-001| A aplicação deve permitir cadastro de usuario | Yago | UsuariosController.cs | CadastroDto, Usuario | POST /api/Usuarios | ✅ |
|RF-002| A aplicação deve permitir deletar o usuario | Yago | UsuariosController.cs | Usuario | DELETE /api/Usuarios/{id} | ✅ |
|RF-003| A aplicação deve permitir alterar os dados do usuario | Yago | UsuariosController.cs | Usuario | PUT /api/Usuarios/{id} | ✅ |
|RF-004| A aplicação deve autenticar o login | Yago | UsuariosController.cs | LoginDto, Usuario | POST /api/Usuarios/login | ✅ |
|RF-005| A aplicação deve gerenciar a conexão a API do spotify | Gustavo/Vinicius | Artefato Criado | Estruturas de Dados | Teste/API | ❌ |
|RF-006| A aplicação deve permitir buscar por uma musica | Gustavo/Vinicius | Artefato Criado | Estruturas de Dados | Teste/API | ❌ |
|RF-007| A aplicação deve permitir o usuario a analisar uma musica | Daniel | Avaliação.cs| Avaliação | POST /api/Avaliacao | ✅ |
|RF-008| A aplicação deve permitir o usuario a deletar uma analise | Daniel | Avaliação.cs | Avaliação | DELETE /api/Avaliacao/{id} |✅ |
|RF-009| A aplicação deve permitir o usuario a comentar em uma analise | Daniel | Comentário.cs | Avaliação e Comentário | POST /api/Comentario | ✅ |
|RF-010| A aplicação deve permitir o usuario a deletar um comentario | Daniel | Comentário.cs | Avaliação e Comentário | DELETE /api/Comentario/{id} | ✅ |
|RF-011| A aplicação deve recomendar musicas | Carol | Artefato Criado | Estruturas de Dados | Teste/API | ❌ |
|RF-012| A aplicação deve recomendar analises | Carol | Artefato Criado | Estruturas de Dados | Teste/API | ❌ |
|RF-013| A aplicação deve recomendar perfis | Carol | Artefato Criado | Estruturas de Dados | Teste/API | ❌ |

#### Requisitos não Funcionais
|ID     | Descrição do Requisito  | Atendido |
|-------|-------------------------|----|
|RNF-001| A aplicação deve processar requisições do usuário em no máximo 3s | ✅ |
|RNF-002| A aplicação deve ser intuitiva para um uso simples | ✅ |

✅ - Atendido
❌ - Não Atendido

### Estrutura de Dados
#### Usuario
(src\Autenticação e Gestão do Usuário\Autenticacao_e_Gestao_do_Usuario\Models\Usuario) <br>
```js
{
  "id*": int,
  "nome*": "string",
  "email*": "string",
  "senha*": "string",
  "perfil": "string",
  "status": int,
  "criado_Em*": "datetime",
  "alterado_Em": "datetime"
}

- Os campos com `*` são obrigatórios.
- "perfil" deve ser "Usuario" ou "Administrador".
- "status" é um `int` que referencia uma linha da tabela `Status`.
- "criado_Em" e "alterado_Em" são definidos automaticamente pela API.
```

#### Status
(src\Autenticação e Gestão do Usuário\Autenticacao_e_Gestao_do_Usuario\Models\Status) <br>
```js
{
  "id*": int,
  "descricao*": "string",
  "criado_Em*": "datetime",
  "alterado_Em": "datetime"
}

- Os campos com `*` são obrigatórios.
- "criado_Em" e "alterado_Em" são definidos automaticamente pela API.
```

#### LoginDto
(src\Autenticação e Gestão do Usuário\Autenticacao_e_Gestao_do_Usuario\Models\DTO\LoginDto) <br>
```js
{
  "email*": "string",
  "senha*": "string",
}

- Os campos com `*` são obrigatórios.
```

#### CadastroDto
(src\Autenticação e Gestão do Usuário\Autenticacao_e_Gestao_do_Usuario\Models\DTO\CadastroDto) <br>
```js
{
  "nome*": "string",
  "email*": "string",
  "senha*": "string",
  "perfil": "string",
}

- Os campos com `*` são obrigatórios.
- "perfil" deve ser "Usuario" ou "Administrador".
```

#### AlterarUsuarioDto
(src\Autenticação e Gestão do Usuário\Autenticacao_e_Gestao_do_Usuario\Models\DTO\AlterarUsuarioDto) <br>
```js
{
  "nome*": "string",
  "email*": "string",
  "senha*": "string",
  "perfil": "string",
  "status": int,
}

- Os campos com `*` são obrigatórios.
- "perfil" deve ser "Usuario" ou "Administrador".
- "status" é um `int` que referencia uma linha da tabela `Status`.
```

#### Avaliação

#### Comentários
