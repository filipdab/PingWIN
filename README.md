# PingWIN

Monitor dostępności hostów w czasie rzeczywistym dla Windows – prosta aplikacja WinForms z ciemnym motywem, która cyklicznie pinguje listę adresów i pokazuje ich stan oraz statystyki.

## Funkcje

- Monitorowanie wielu hostów (adres IP lub nazwa hosta) z opcjonalną, edytowalną nazwą
- Status hosta: **online**, **wolny** (czas odpowiedzi > 150 ms), **offline**
- Statystyki: ostatni czas, średnia, min / max, procent utraty pakietów, wysłane / odebrane
- Wykres historii ostatnich 40 prób dla każdego hosta
- Regulowany interwał pingowania i timeout
- Ręczne pingowanie, reset statystyk i kopiowanie adresów zaznaczonych hostów (menu kontekstowe)
- Automatyczny zapis listy hostów w `%APPDATA%\PingWIN\hosts.txt`
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

## Obsługa

| Akcja | Sposób |
|---|---|
| Dodanie hosta | Wpisz adres (i opcjonalnie nazwę), kliknij **Dodaj** lub naciśnij Enter |
| Start / stop monitorowania | Przycisk **Start** / **Stop** |
| Zmiana nazwy | Kliknij dwukrotnie komórkę w kolumnie **NAZWA** |
| Usunięcie hosta | Zaznacz i naciśnij Delete lub kliknij **Usuń zaznaczone** |
| Więcej opcji | Prawy przycisk myszy na liście hostów |

## Autor

**filipdab**
