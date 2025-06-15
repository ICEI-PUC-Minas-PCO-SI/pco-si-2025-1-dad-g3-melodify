## Testes

Esta seção descreve a estratégia de testes adotada para garantir a qualidade, segurança e desempenho da aplicação.

### Tipos de Testes

1. **Crie casos de teste para cobrir todos os requisitos funcionais e não funcionais da aplicação.**  
   - Cada requisito (cadastro, login, avaliações, comentários, músicas, playlists, recomendações) foi testado com cenários válidos e inválidos.

2. **Implemente testes unitários para testar unidades individuais de código, como funções e classes.**  
   - As funções de validação de DTOs, manipulação de entidades e regras de negócio foram verificadas individualmente.

3. **Realize testes de integração para verificar a interação correta entre os componentes da aplicação.**  
   - Testamos a integração entre controllers, serviços e banco de dados usando Postman, Swagger e Newman.  
   - Requisições completas foram simuladas do início ao fim (ex: login, avaliar música, comentar).

4. **Execute testes de carga para avaliar o desempenho da aplicação sob carga significativa.**  
   - Utilizamos o Newman com scripts de múltiplas requisições simultâneas para simular acesso em massa aos endpoints principais.

5. **Utilize ferramentas de teste adequadas, como frameworks de teste e ferramentas de automação de teste, para agilizar o processo de teste.**  
   - As ferramentas utilizadas foram:
     - **Swagger**: para testes manuais e documentação da API.
     - **Postman**: para criar e validar requisições REST.
     - **Newman**: para automatizar testes do Postman e simular carga.

---

### Cobertura de Testes por Requisito

| Requisito | Teste Manual (Swagger) | Teste Automatizado (Postman/Newman) | Observações |
| --------- | ---------------------- | ----------------------------------- | ----------- |
| RF-001 - Cadastro de usuário | ✅ | ✅ | Verificação de campos obrigatórios e e-mail único |
| RF-002 - Deletar usuário | ✅ | ✅ | Testado com ID válido e inválido |
| RF-003 - Alterar usuário | ✅ | ✅ | Testado para atualização parcial e completa |
| RF-004 - Login | ✅ | ✅ | Testado com credenciais corretas e incorretas |
| RF-005 - Integração Spotify | ✅ | ✅ | Retorno de músicas e tokens |
| RF-006 - Buscar música | ✅ | ✅ | Busca via Spotify |
| RF-007 - Avaliar música | ✅ | ✅ | Avaliação com e sem texto |
| RF-008 - Deletar análise | ✅ | ✅ | Validação de existência |
| RF-009 - Comentar análise | ✅ | ✅ | Ligação correta com avaliação |
| RF-010 - Deletar comentário | ✅ | ✅ | Comentário existente e não existente |
| RF-011/012/013 - Recomendações | ✅ | ✅ | Por tipos existentes de recomendações |

---

### Exemplos de Casos de Teste

- Criar usuário com dados válidos → `201 Created`  
- Login com senha errada → `401 Unauthorized`  
- Buscar música existente no Spotify → `200 OK` com dados completos  
- Deletar comentário com ID inexistente → `404 Not Found`  

---

### Ferramentas Utilizadas

- **Swagger** – Testes manuais de endpoints com interface interativa.  
- **Postman** – Criação de coleções de testes com diferentes cenários.  
- **Newman** – Execução em linha de comando das coleções do Postman, inclusive para testes de carga simples.

---

### Processo de Teste Automatizado

- As coleções do Postman foram exportadas e utilizadas no Newman.  
- Resultados foram verificados por status HTTP, tempo de resposta e mensagens de erro.

---

