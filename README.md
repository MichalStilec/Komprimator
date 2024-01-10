# Popis programu
Program je konzolová aplikace napsaná v jazyce C#, která provádí kompresi textového souboru odstraněním samohlásek ze slov. Program také umožňuje uživateli manipulovat s vstupními a výstupními soubory a spravovat místo, kam jsou ukládány logy.

# Struktura programu

## Třída Program

### Metoda Main
- Nastavuje kódování pro podporu českých znaků.
- Inicializuje konfiguraci a logy.
- Načítá cesty k vstupnímu souboru, výslednému souboru a souboru s logy.
- Zobrazuje uživatelské rozhraní s možnostmi a volbami.
- Obsahuje smyčku, která umožňuje uživateli provádět operace, dokud není zvolena možnost ukončení programu.
  
### Metoda RunUnitTests
- Obsahuje unit testy pro metody RemoveVowelsFromWords a RemoveVowels.
- Vypisuje vstupy a očekávané výstupy.
- Čeká na stisknutí ENTER pro pokračování.
  
### Metoda RemoveVowelsFromWords
- Rozděluje text na slova.
- Odstraňuje samohlásky ze slov.
- Vrací modifikovaný text.
  
### Metoda RemoveVowels
- Odstraňuje samohlásky ze zadaného řetězce.
- Vrací modifikovaný řetězec.
  
## Třída Config

### Metoda LoadInput a LoadResult
- Načítá cestu k vstupnímu/výslednému souboru z konfiguračního souboru.
- Kontroluje existenci souboru.
- Vrací načtenou cestu nebo výchozí hodnotu.

## Třída Logs
### Metoda LogSuccess
- Zaznamenává úspěšné zprávy do logu ve formátu JSON.
### Metoda LogFail
- Zaznamenává neúspěšné zprávy do logu ve formátu JSON.
### Metoda LogError
- Zaznamenává chyby do logu ve formátu JSON.
  
## Způsob použití
1. Program načte konfiguraci a vytvoří instance tříd Config a Logs.
2. Uživatel volí operace pomocí uživatelského rozhraní.
3. Program provádí kompresi textového souboru odstraněním samohlásek.
4. Výsledný komprimovaný text se uloží do souboru specifikovaného v konfiguraci.
5. Logy se ukládají do souboru ve formátu JSON.

## Ostatní poznámky
- Program pracuje s českými znaky díky nastavení kódování na Encoding.UTF8.
- Cesty k souborům jsou konfigurovány v konfiguračním souboru a logy jsou ukládány ve formátu JSON.
- Program obsahuje ochranu před chybami a zachycuje výjimky, které jsou zaznamenány v logu.
- Uživatelské rozhraní nabízí uživateli snadné ovládání programu.
