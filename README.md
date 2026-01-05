# JobApplicationTracker

Detta projekt är ett konsolprogram som låter användaren registrera, visa och hantera jobbansökningar. Programmet är uppbyggt enligt kursens krav och använder flera Git‑branches för att utveckla olika funktioner.

## Funktioner
- Lägga till nya jobbansökningar
- Visa alla ansökningar
- Visa statistik (LINQ)
- Enkel meny för navigation

## Git‑arbetsflöde
Projektet är utvecklat med ett strukturerat Git‑flöde:

- **main** – stabil branch
- **feature-linq** – statistikfunktion med LINQ
- **feature-menu** – förbättrad meny
- **development** – övriga förbättringar

Alla branches har:
- egna commits  
- push till GitHub  
- pull requests  
- merge till main  

## Branch Protection
Main‑branchen är skyddad med:
- *Require a pull request before merging*

Detta säkerställer att inga ändringar kan pushas direkt till main utan PR.

## Hur man kör programmet
1. Klona repot  
2. Öppna projektet i Visual Studio  
3. Kör programmet via `Program.cs`
