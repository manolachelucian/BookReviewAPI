# ReviewApp

Tento projekt je RESTful API postavené na ASP.NET Core, určené pro správu knih, autorů, uživatelů a recenzí pro platformu recenzí knih. Využívá Entity Framework Core pro interakci s databází a používá vzor repozitáře k oddělení logiky od přístupu k datům.

## Funkce
- **Správa uživatelů**: Vytváření, aktualizace, mazání a získávání dat uživatelů.
- **Správa knih**: Správa knih, autorů a žánrů, včetně jejich propojení (many-to-many vztahy).
- **Správa recenzí**: Uživatelé mohou přidávat recenze ke knihám, které se ukládají a zobrazují.
- **Seedování dat**: Poskytnuta je třída Seed, která naplní databázi počátečními daty.
- **AutoMapper**: Používá se k mapování mezi modely domény a DTO.
- **Dependency Injection**: Služby, jako jsou repozitáře a třída Seed, jsou injektovány pomocí vestavěného dependency injection v ASP.NET Core.
## Struktura projektu
- DataContext: Definuje databázový kontext a vztahy mezi entitami.
- Repositoria: Poskytují vrstvu pro přístup a manipulaci s daty v databázi.
- Kontrolery: RESTful API kontrolery pro uživatele, knihy, autory a recenze.
- DTOs: Data transfer objekty, které definují, jaká data jsou vystavována přes API.
- AutoMapper Profily: Konfigurace mapování pro převod mezi modely domény a DTO.

## Použité technologie
- ** ASP.NET Core 6.0
- ** Entity Framework Core
- ** AutoMapper
- ** SQL Server
- ** .NET 8
- ** MVC Architektura

## Instalace
```bash
git clone https://github.com/vas-repo/book-review-api.git
cd book-review-api
dotnet restore
dotnet ef database update
dotnet run
