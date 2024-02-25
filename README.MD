# CADÁSTRO DE MATÉRIAS E ALUNOS


### Tecnologias Utilizadas

- Plataforma: .NET 8.0
- Framework Web: ASP.NET Core
- Acesso a Dados: EF Core
- Banco de Dados: SQL Server

### Estrutura das Camadas da Aplicação

1. **school-management.domain:** Nesta camada, encontra-se toda a regra de negócio e o coração da aplicação. Aqui, são definidas as entidades de domínio, enums e validações de domínio.

2. **school-management.application:** Aqui ficam todas as regras de aplicação dentro dos casos de uso. 

3. **school-management.infra:** Responsável pela persistência de dados. Também pode ser utilizada para adicionar serviços externos da aplicação, como mensageria e gateways.

4. **school-management.api:** Camada web da aplicação, responsável por resolver as dependências da aplicação.

4. **school-management.shared:** Camada responsável por armazenamento de dados que serão utilizados em outras camadas.

### Padrões e Arquitetura

Optou-se pelo uso de padrões da arquitetura limpa e DDD (Domain-Driven Design). Esses padrões prezam pelo isolamento do core da aplicação em camadas, tornando-a mais manutenível e testável. Embora seja uma aplicação simples, a utilização desses padrões foi uma oportunidade para aplicar conceitos e conhecimentos avançados.

### Deploy da aplicação

https://school-management-api.azurewebsites.net/swagger/index.html

