# SOLID (.NET 9 + Serilog + FluentValidation)

Este é um projeto de exemplo construído com .NET 9 para demonstrar a aplicação explícita de todos os **princípios SOLID** em um sistema de **cadastro de produtos**, utilizando **Serilog** para logging e **FluentValidation** para validações.

---

## Tecnologias
- .NET 9
- Serilog
- FluentValidation
- Injeção de Dependência

---

## Estrutura do Projeto

```
SOLID/
├── Domain/
├── Application/
├── Infrastructure/
└── Presentation/
```

---

## Princípios SOLID Aplicados

### 1. **S** - Single Responsibility Principle (Responsabilidade Única)

Cada classe tem **uma única responsabilidade**.

`CreateProductDtoValidator.cs` é responsável **somente pela validação de entrada**:

```csharp
public class CreateProductDtoValidator : AbstractValidator<CreateProductDto>
{
    public CreateProductDtoValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Product name is required.");

        RuleFor(x => x.Price)
            .GreaterThan(0).WithMessage("Price cannot be negative.");
    }
}
```

`CreateProductUseCase.cs` lida **somente com a lógica de uso**.

---

### 2. **O** - Open/Closed Principle (Aberto para extensão, fechado para modificação)

Utilizamos **interfaces e injeção de dependência** para permitir extensões futuras sem alterar código existente.

Validação pode ser facilmente trocada substituindo o validador:

```csharp
services.AddSingleton<IValidator<CreateProductDto>, CreateProductDtoValidator>();
```

Substituir Serilog por NLog:

```csharp
De
services.AddSingleton<ILoggerService, SerilogLogger>();
Para
services.AddSingleton<ILoggerService, NLogLogger>();
```

Substituir Repositório em memória por ProductRepository:

```csharp
De
services.AddSingleton<IProductRepository, InMemoryProductRepository>();
Para
services.AddSingleton<IProductRepository, ProductRepository>();
```
---

### 3. **L** - Liskov Substitution Principle (Substituição de Liskov)

As dependências de `CreateProductUseCase` são baseadas em abstrações e podem ser substituídas sem impacto:

```csharp
public CreateProductUseCase(
    IProductRepository repository,
    ILoggerService logger,
    IValidator<CreateProductDto> validator)
```

---

### 4. **I** - Interface Segregation Principle (Segregação de Interface)

Criamos **interfaces pequenas e específicas**:

```csharp
public interface IProductRepository
{
    void Add(Product product);
    IEnumerable<Product> GetAll();
}
```

```csharp
public interface ILoggerService
{
    void Info(string message);
    void Error(string message);
}
```

Cada classe implementa apenas o que é necessário.

---

### 5. **D** - Dependency Inversion Principle (Inversão de Dependência)

As camadas superiores **não conhecem as implementações concretas**, apenas interfaces.

Em `Program.cs`, a aplicação injeta dependências via métodos de extensão:

```csharp
services.AddMyApplication();
services.AddMyInfrastructure();
```

Em `Application`:

```csharp
services.AddTransient<ICreateProductUseCase, CreateProductUseCase>();
services.AddSingleton<IValidator<CreateProductDto>, CreateProductDtoValidator>();
```

Em `Infrastructure`:

```csharp
services.AddSingleton<IProductRepository, InMemoryProductRepository>();
services.AddSingleton<ILoggerService, SerilogLogger>();
```

---

## Executando o Projeto

### 1. Clonar o repositório
```bash
git clone https://github.com/Fernando2020/SOLID.git
cd SOLID
```

### 2. Restaurar pacotes
```bash
dotnet restore
```

### 3. Rodar aplicação
```bash
cd src\SOLID.Presentation
dotnet run
```

---

## Exemplo de Execução

```
[20:50:29 INF] Product 'Notebook Dell' added successfully.
```

---
