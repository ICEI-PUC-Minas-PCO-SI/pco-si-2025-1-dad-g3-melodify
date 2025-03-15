# Introdução

A música desempenha um papel essencial na vida das pessoas, influenciando emoções, criando conexões e moldando experiências. Com o crescimento das plataformas de streaming, os ouvintes dispõem de um extenso catálogo de músicas, porém frequentemente encontram obstáculos para descobrir novas canções que realmente se adequem aos seus gostos. A sugestão baseada apenas em algoritmos pode ser restrita, uma vez que não leva em conta as particularidades e vivências individuais de cada ouvinte. Neste cenário, fica clara a necessidade de um método mais interativo e colaborativo para sugestões musicais.

O principal desafio que procuramos solucionar é a ausência de uma plataforma especializada em recomendações musicais, onde os usuários possam avaliar músicas, trocar opiniões e interagir com outros entusiastas do gênero musical. Nossa proposta é criar uma plataforma que combina tecnologia e interação social para tornar a experiência de descoberta musical mais rica e personalizada.

O objetivo principal do projeto é desenvolver uma rede social de recomendação de músicas, onde os usuários possam atribuir notas, comentar e indicar faixas para amigos e outros membros da comunidade.

A justificativa para esse projeto reside na crescente demanda por experiências sociais no consumo de mídia digital. A interação social tem se mostrado um fator decisivo para o engajamento dos usuários em diversas plataformas, como demonstrado pelo sucesso de redes sociais voltadas ao compartilhamento de experiências e preferências. Com a criação desta ferramenta, buscamos preencher uma lacuna existente no mercado, promovendo não apenas a descoberta de novas músicas, mas também a interação significativa entre os ouvintes.

## Problema

A música é uma forma de expressão universal, que conecta as pessoas ao redor do mundo. No entanto, apesar da abundância de plataformas de streaming e redes sociais, não existe um espaço centralizado e focado exclusivamente na interação entre pessoas que querem compartilhar, avaliar e descobrir músicas de forma colaborativa.

Atualmente, os usuários recorrem a diferentes meios para expressar suas opiniões sobre músicas e álbuns, como comentários em vídeos, fóruns dispersos ou redes sociais generalistas, que não oferecem funcionalidades específicas para esse propósito. Isso fragmenta a experiência e dificulta a descoberta de novas músicas com base nas avaliações da comunidade.

Além disso, artistas independentes e novos talentos encontram dificuldades para alcançar um público engajado que valorize suas produções, já que as grandes plataformas priorizam artistas mais conhecidos ou dependem de algoritmos fechados para recomendações.

## Objetivos

O objetivo geral é desenvolver um software que servirá como uma rede social para quem gosta de músicas e serve para avaliar/recomendar músicas.

Objetivos específicos:

-Conectar pessoas através da música.

-Permitir que as pessoas compartilhem suas opiniões sobre músicas, álbuns e artistas para novas ideias.

-Ajudar as pessoas a encontrarem boas recomendações de músicas.

-Permitir com que as pessoas conversem sobre suas preferências musicais.

## Justificativa

A música desempenha um papel essencial na vida das pessoas, seja como forma de entretenimento, expressão pessoal ou conexão social. De acordo com um estudo da IFPI (International Federation of the Phonographic Industry), em 2023, as pessoas passaram, em média, 20,7 horas por semana ouvindo música, um aumento significativo em relação aos anos anteriores. No entanto, apesar desse consumo crescente, as formas de interação e compartilhamento musical ainda são limitadas a plataformas não especializadas ou com algoritmos que priorizam grandes artistas e dificultam a descoberta de novas músicas e talentos.

A ausência de um espaço digital voltado exclusivamente para a troca de opiniões, avaliações e recomendações musicais impacta tanto ouvintes quanto artistas independentes. Segundo dados da plataforma do Spotify, existem mais de 100 milhões de faixas disponíveis, mas estima-se que cerca de 80% das reproduções sejam concentradas em apenas 1% dos artistas. Isso evidencia um problema na descoberta de novas músicas, tornando difícil para ouvintes explorarem sons além das recomendações automatizadas.

A criação de uma rede social dedicada ao compartilhamento e avaliação de músicas atende a essa necessidade, permitindo que qualquer pessoa descubra novas faixas por meio de recomendações autênticas e interações diretas com a comunidade. Além disso, proporciona um ambiente mais acessível para artistas independentes divulgarem seu trabalho, democratizando o acesso à música e criando novas oportunidades para talentos emergentes.

Diante desse cenário, este projeto se justifica pela necessidade de um espaço colaborativo onde ouvintes e criadores possam se conectar de maneira mais orgânica, sem depender exclusivamente de algoritmos fechados ou de redes sociais generalistas que não foram projetadas para essa finalidade.

## Público-Alvo

O Melodify tem como público-alvo jovens e adultos entre 18 a 30 anos que residem no Brasil ou falam português, independentemente do nível de familiaridade com a tecnologia, pois a plataforma é acessível diretamente pelo navegador, oferece uma experiência simples e intuitiva. O único requisito é a paixão pela música. O Melodify é ideal para quem deseja recomendar, avaliar e interagir com outros usuários de gostos musicais semelhantes, proporcionando novas experiências de descoberta e compartilhamento musical.

# Especificações do Projeto

Definição do problema e ideia de solução a partir da perspectiva do usuário. É composta pela definição do  diagrama de personas, histórias de usuários, requisitos funcionais e não funcionais além das restrições do projeto.

Apresente uma visão geral do que será abordado nesta parte do documento, enumerando as técnicas e/ou ferramentas utilizadas para realizar a especificações do projeto.

Caso deseje atribuir uma imagem a sua persona, utilize o site https://thispersondoesnotexist.com/

## Personas

### Persona 1 - Felipe Mendes (O Explorador Musical)
**Idade:** 25 anos  
**Profissão:** Arquiteto recém-formado e autônomo  

**Objetivos:**
- Explorar novos estilos musicais enquanto trabalha ou viaja  
- Compartilhar suas opiniões sobre músicas  
- Encontrar recomendações musicais personalizadas  

**Desafios:**
- Falta de tempo para pesquisar novas músicas  
- Dificuldade em encontrar recomendações certeiras  

**Funcionalidades mais relevantes:**  
- **Gestão de Músicas:** Buscar músicas e integração com o Spotify  
- **Avaliação e Comentários:** Criar análises sobre músicas  
- **Recomendações:** Receber sugestões personalizadas  

### Persona 2 - Larissa Mendes (A Crítica Musical)
**Idade:** 30 anos  
**Profissão:** Jornalista musical e produtora de conteúdo  

**Objetivos:**
- Criar análises detalhadas sobre álbuns e singles  
- Engajar com a comunidade musical  
- Receber recomendações baseadas no seu gosto  

**Desafios:**
- Encontrar uma plataforma para compartilhar críticas  
- Manter um histórico organizado das suas análises  

**Funcionalidades mais relevantes:**  
- **Avaliação e Comentários:** Criar e deletar análises e comentários  
- **Autenticação:** Manter um perfil confiável na plataforma  
- **Recomendações:** Descobrir novas músicas e críticas  

### Persona 3 - Gustavo Ferreira (O Desenvolvedor Entusiasta de IA)
**Idade:** 22 anos  
**Profissão:** Estudante de Ciência da Computação  

**Objetivos:**
- Explorar e contribuir para o sistema de recomendação musical  
- Testar e otimizar algoritmos de recomendação  
- Criar perfis para testar personalizações  

**Desafios:**
- Encontrar métricas sobre o funcionamento do sistema  
- Lidar com autenticação e gerenciamento da API do Spotify  

**Funcionalidades mais relevantes:**  
- **Recomendações:** Testar sugestões de músicas e perfis  
- **Autenticação:** Criar contas para simulações  
- **Gestão de Músicas:** Analisar como os tokens da API são gerenciados  

### Persona 4 - Mariana Rocha (A Ouvinte Casual)
**Idade:** 35 anos  
**Profissão:** Gerente de Projetos  

**Objetivos:**
- Descobrir novas músicas rapidamente  
- Ler avaliações antes de escolher playlists  
- Criar listas de músicas para diferentes momentos do dia  

**Desafios:**
- Falta de tempo para explorar novos estilos  
- Evitar recomendações que não combinam com seu gosto  

**Funcionalidades mais relevantes:**  
- **Recomendações:** Receber sugestões diretas  
- **Avaliação e Comentários:** Ler avaliações antes de escolher uma música  
- **Gestão de Músicas:** Buscar músicas por categorias e estilos 

## Histórias de Usuários

Com base na análise das personas forma identificadas as seguintes histórias de usuários:

|EU COMO... `PERSONA` | QUERO/PRECISO ... `FUNCIONALIDADE`                 | PARA ... `MOTIVO/VALOR`                                    |
|---------------------|----------------------------------------------------|------------------------------------------------------------|
|Usuário do sistema   | Criar uma conta                                    | Acessar a aplicação                                        |
|Usuário do sistema   | Excluir minha conta                                | Remover meus dados do sistema                              |
|Usuário do sistema   | Fazer login na plataforma                          | Acessar meus dados e preferências                          |
|Usuário do sistema   | Avaliar músicas e álbuns                           | Ajudar outras pessoas a descobrir boas músicas             |
|Usuário do sistema   | Comentar em avaliações de outros usuários          | Compartilhar minha opinião                                 |
|Usuário do sistema   | Seguir outros usuários                             | Acompanhar recomendações de pessoas com gostos similares   |
|Usuário do sistema   | Marcar músicas como favoritas                      | Acessá-las facilmente depois                               |
|Usuário do sistema   | Receber recomendações personalizadas de músicas    | Descobrir novas músicas que combinem com meu gosto         |
|Usuário do sistema   | Criar playlists baseadas nos meus gostos           | Organizar minhas descobertas musicais de forma prática     |
|Usuário do sistema   | Compartilhar minhas avaliações sobre músicas       | Expressar minha opinião e ajudar outras pessoas            |
|Usuário do sistema   | Criar análises detalhadas sobre álbuns e singles   | Compartilhar meu conhecimento com a comunidade musical     |
|Usuário do sistema   | Editar e excluir minhas análises                   | Manter meu conteúdo atualizado e relevante                 |
|Usuário do sistema   | Seguir outros usuários                             | Acompanhar as opiniões de pessoas com gostos similares     |
|Usuário do sistema   | Ter um perfil público com histórico de críticas    | Construir minha reputação na plataforma                    |
|Usuário do sistema   | Receber sugestões sem precisar pesquisar           | Encontrar boas músicas sem perder tempo                    |
|Usuário do sistema   | Ler avaliações antes de escolher playlists         | Garantir que estou ouvindo algo que combina comigo         |
|Usuário do sistema   | Filtrar músicas por categorias e estilos           | Encontrar rapidamente o que desejo ouvir                   |
|Artista independente | Divulgar minhas músicas na plataforma              | Alcançar um público interessado no meu estilo musical      |
|Artista independente | Criar um perfil de artista                         | Divulgar meu trabalho e alcançar um novo público           |
|Artista independente | Publicar minhas músicas na plataforma              | Tornar meu trabalho acessível a mais pessoas               |
|Artista independente | Receber feedback e avaliações dos usuários         | Melhorar minhas produções musicais com base nas opiniões   |


## Requisitos

As tabelas que se seguem apresentam os requisitos funcionais e não funcionais que detalham o escopo do projeto.

### Requisitos Funcionais

|ID    | Descrição do Requisito  | Prioridade | 
|------|-----------------------------------------|----| 
|RF-001| A aplicação deve permitir que o usuário gerencie suas tarefas | ALTA |  
|RF-002| A aplicação deve permitir a emissão de um relatório de tarefas realizadas no mês   | MÉDIA | 


### Requisitos não Funcionais

|ID     | Descrição do Requisito  |Prioridade |
|-------|-------------------------|----|
|RNF-001| A aplicação deve ser responsiva | MÉDIA | 
|RNF-002| A aplicação deve processar requisições do usuário em no máximo 3s |  BAIXA | 

Com base nas Histórias de Usuário, enumere os requisitos da sua solução. Classifique esses requisitos em dois grupos:

- [Requisitos Funcionais
 (RF)](https://pt.wikipedia.org/wiki/Requisito_funcional):
 correspondem a uma funcionalidade que deve estar presente na
  plataforma (ex: cadastro de usuário).
- [Requisitos Não Funcionais
  (RNF)](https://pt.wikipedia.org/wiki/Requisito_n%C3%A3o_funcional):
  correspondem a uma característica técnica, seja de usabilidade,
  desempenho, confiabilidade, segurança ou outro (ex: suporte a
  dispositivos iOS e Android).
Lembre-se que cada requisito deve corresponder à uma e somente uma
característica alvo da sua solução. Além disso, certifique-se de que
todos os aspectos capturados nas Histórias de Usuário foram cobertos.

## Restrições

O projeto está restrito pelos itens apresentados na tabela a seguir.

|ID| Restrição                                             |
|--|-------------------------------------------------------|
|01| O projeto deverá ser entregue até o final do semestre |
|02| Não pode ser desenvolvido um módulo de backend        |


Enumere as restrições à sua solução. Lembre-se de que as restrições geralmente limitam a solução candidata.

> **Links Úteis**:
> - [O que são Requisitos Funcionais e Requisitos Não Funcionais?](https://codificar.com.br/requisitos-funcionais-nao-funcionais/)
> - [O que são requisitos funcionais e requisitos não funcionais?](https://analisederequisitos.com.br/requisitos-funcionais-e-requisitos-nao-funcionais-o-que-sao/)

# Arquitetura da Solução

Definição de como o software é estruturado em termos dos componentes que fazem parte da solução e do ambiente de hospedagem da aplicação.

![arq](https://github.com/user-attachments/assets/b9402e05-8445-47c3-9d47-f11696e38a3d)

## Tecnologias Utilizadas

Descreva aqui qual(is) tecnologias você vai usar para resolver o seu problema, ou seja, implementar a sua solução. Liste todas as tecnologias envolvidas, linguagens a serem utilizadas, serviços web, frameworks, bibliotecas, IDEs de desenvolvimento, e ferramentas.

Apresente também uma figura explicando como as tecnologias estão relacionadas ou como uma interação do usuário com o sistema vai ser conduzida, por onde ela passa até retornar uma resposta ao usuário.

# Planejamento do projeto

##  Divisão de papéis

> Apresente a divisão de papéis entre os membros do grupo em cada Sprint. O desejável é que, em cada Sprint, o aluno assuma papéis diferentes na equipe. Siga o modelo do exemplo abaixo:

### Sprint 1
- _Scrum master_: AlunaX
- Protótipos: AlunoY
- Testes: AlunoK
- Documentação: AlunaZ

### Sprint 2
- _Scrum master_: AlunaY
- Desenvolvedor _front-end_: AlunoX
- Desenvolvedor _back-end_: AlunoK
- Testes: AlunaZ

##  Quadro de tarefas

> Apresente a divisão de tarefas entre os membros do grupo e o acompanhamento da execução, conforme o exemplo abaixo.

### Sprint 1

Atualizado em: 07/03/2025

| Responsável   | Tarefa/Requisito | Iniciado em    | Prazo      | Status | Terminado em    |
| :----         |    :----         |      :----:    | :----:     | :----: | :----:          |
| Gustavo        | README introdutório | 07/03/2025 | 07/03/2025 | ✔️ | 07/03/2025 |
| Daniel        | Objetivos | 07/03/2025 | 07/03/2025 | ✔️ | 07/03/2025 |
| Carolina       | Problema | 07/03/2025 | 07/03/2025 | ✔️ | 07/03/2025 |
| Carolina       | Justificativa | 07/03/2025 | 07/03/2025 | ✔️ | 07/03/2025 |
| Vinicius       | Introdução | 07/03/2025 | 07/03/2025 | ✔️  | 07/03/2025 |
| Yago      | Público-Alvo | 07/03/2025 | 07/03/2025 | ✔️  | 07/03/2025 |
|  |  |  |  |  |  |

### Sprint 2

Atualizado em: 21/04/2024

| Responsável   | Tarefa/Requisito | Iniciado em    | Prazo      | Status | Terminado em    |
| :----         |    :----         |      :----:    | :----:     | :----: | :----:          |
| AlunaX        | Página inicial   | 01/02/2024     | 07/03/2024 | ✔️    | 05/02/2024      |
| AlunaZ        | CSS unificado    | 03/02/2024     | 10/03/2024 | 📝    |                 |
| AlunoY        | Página de login  | 01/02/2024     | 07/03/2024 | ⌛     |                 |
| AlunoK        | Script de login  |  01/01/2024    | 12/03/2024 | ❌    |       |


Legenda:
- ✔️: terminado
- 📝: em execução
- ⌛: atrasado
- ❌: não iniciado


> **Links úteis**:
> - [11 passos essenciais para implantar Scrum no seu projeto](https://mindmaster.com.br/scrum-11-passos/)
> - [Scrum em 9 minutos](https://www.youtube.com/watch?v=XfvQWnRgxG0)
> - [Os papéis do Scrum e a verdade sobre cargos nessa técnica](https://www.atlassian.com/br/agile/scrum/roles)

## Processo

Coloque informações sobre detalhes da implementação do Scrum seguido pelo grupo. O grupo deverá fazer uso do recurso de gerenciamento de projeto oferecido pelo GitHub, que permite acompanhar o andamento do projeto, a execução das tarefas e o status de desenvolvimento da solução.
 
> **Links úteis**:
> - [Planejamento e gestão ágil de projetos](https://pucminas.instructure.com/courses/87878/pages/unidade-2-tema-2-utilizacao-de-ferramentas-para-controle-de-versoes-de-software)
> - [Sobre quadros de projeto](https://docs.github.com/pt/issues/organizing-your-work-with-project-boards/managing-project-boards/about-project-boards)
> - [Project management, made simple](https://github.com/features/project-management/)
> - [Como criar backlogs no GitHub](https://www.youtube.com/watch?v=RXEy6CFu9Hk)
> - [Tutorial slack](https://slack.com/intl/en-br/)

## Ferramentas

Liste todas as ferramentas que foram empregadas no projeto, justificando a escolha delas, sempre que possível.

Exemplo: os artefatos do projeto são desenvolvidos a partir de diversas plataformas e a relação dos ambientes com seu respectivo propósito é apresentada na tabela que se segue.

| Ambiente                            | Plataforma                         | Link de acesso                         |
|-------------------------------------|------------------------------------|----------------------------------------|
| Repositório de código fonte         | GitHub                             | https://github.com/ICEI-PUC-Minas-PCO-SI/pco-si-2025-1-dad-g3-melodify                           |
| Documentos do projeto               | GitHub                             | https://github.com/ICEI-PUC-Minas-PCO-SI/pco-si-2025-1-dad-g3-melodify/tree/docs/docs                            |
| Projeto de interface                | Figma                              | http://....                            |
| Gerenciamento do projeto            | GitHub Projects                    | https://github.com/ICEI-PUC-Minas-PCO-SI/pco-si-2025-1-dad-g3-melodify/projects?query=is%3Aopen                            |
| Hospedagem                          | Vercel                             | http://....                            |
 
