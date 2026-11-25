# LibraryFines: Claude Code demo

Demo project for the COMP 4976 presentation "Claude Code in VS Code".

A small C# console app that works out library late fines. It has **2 bugs** and some failing tests, so the demo can show the Claude Code workflow: explain → plan → review diffs → run tests → commit.

```bash
dotnet test                          # expect: 8 total, 2 failed
dotnet run --project src/LibraryFines
```
