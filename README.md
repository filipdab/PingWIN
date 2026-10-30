# PingWIN

Monitor dostępności hostów w czasie rzeczywistym dla Windows – prosta aplikacja WinForms z ciemnym motywem, która cyklicznie pinguje listę adresów i pokazuje ich stan oraz statystyki.

## Funkcje

- Monitorowanie wielu hostów (adres IP lub nazwa hosta) z opcjonalną, edytowalną nazwą
- Status hosta: **online**, **wolny** (czas odpowiedzi > 150 ms), **offline**
- Statystyki: ostatni czas, średnia, min / max, procent utraty pakietów, wysłane / odebrane
- Wykres historii ostatnich 40 prób dla każdego hosta
- Regulowany interwał pingowania i timeout
- Ręczne pingowanie, reset statystyk i kopiowanie adresów zaznaczonych hostów (menu kontekstowe)
- Automatyczny zapis listy hostów w pliku `PingWIN.hosts.txt` obok `PingWIN.exe` – lista przenosi się razem z programem
- Ciemny pasek tytułu w Windows 10 (20H1+) i Windows 11

## Wymagania

- Windows 10 / 11
- .NET Framework 4.7.2
- Do kompilacji: Visual Studio 2022 lub nowsze (albo MSBuild)

## Kompilacja i uruchomienie

Otwórz `PingWIN.slnx` w Visual Studio i uruchom projekt (F5) albo zbuduj z wiersza poleceń:

```
msbuild PingWIN\PingWIN.csproj /p:Configuration=Release
```

Plik wykonywalny znajdziesz w `PingWIN\bin\Release\PingWIN.exe`.

## Przenoszenie na inny komputer

Lista hostów zapisuje się w pliku `PingWIN.hosts.txt` w tym samym folderze co `PingWIN.exe`. Aby przenieść program razem z listą, skopiuj oba pliki.

- Przy pierwszym uruchomieniu nowej wersji lista zapisana wcześniej w `%APPDATA%\PingWIN\hosts.txt` jest automatycznie przenoszona do nowego pliku.
- Jeśli folderu programu nie da się zapisać (np. `C:\Program Files`), lista nadal jest trzymana w `%APPDATA%\PingWIN\hosts.txt`.

## Obsługa

| Akcja | Sposób |
|---|---|
| Dodanie hosta | Wpisz adres (i opcjonalnie nazwę), kliknij **Dodaj** lub naciśnij Enter |
| Start / stop monitorowania | Przycisk **Start** / **Stop** |
| Zmiana nazwy | Kliknij dwukrotnie komórkę w kolumnie **NAZWA** |
| Usunięcie hosta | Zaznacz i naciśnij Delete lub kliknij **Usuń zaznaczone** |
| Więcej opcji | Prawy przycisk myszy na liście hostów |

## Autor

**Filip Dąbrowski** ([filipdab](https://github.com/filipdab))
