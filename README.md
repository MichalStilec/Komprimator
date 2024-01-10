# Popis programu
Program je konzolová aplikace napsaná v jazyce C#, která provádí kompresi textového souboru odstraněním samohlásek ze slov. Program také umožňuje uživateli manipulovat s vstupními a výstupními soubory a spravovat místo, kam jsou ukládány logy.

## Způsob použití
1. Uživatel extrahuje zip soubor.
2. Následně spustí exe soubor, který se nachází zde: TxtCompression\bin\Debug\net6.0\TxtCompression.exe.
3. Program by měl být zaplý a můžete si libovolně vybrat možnosti 0-5 dle libosti.

# Struktura programu

## Třída Program

### Metoda Main
- Nastavuje kódování pro podporu českých znaků.
- Inicializuje konfiguraci a logy.
- Načítá cesty k vstupnímu souboru, výslednému souboru a souboru s logy.
- Zobrazuje uživatelské rozhraní s možnostmi a volbami.
- Obsahuje smyčku, která umožňuje uživateli provádět operace, dokud není zvolena možnost ukončení programu.
  
### Metoda RunUnitTests
- Kvůli žádosti aby se program mohl spustit na školním PC jsem nestahoval žádné unit test knihovny
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
  
## Jak měnit soubory
1. Program načte konfiguraci ze souboru TxtCompression\bin\Debug\net6.0\config\config.cfg, zde si můžete změnit počáteční soubory.
2. Program také může načíst soubor dle cesty k vámi zadanému souboru, pro tuto možnost zmáčkněte 2 na začátku programu a cestu uvádějte **bez úvozovek!**
3. Program má taky možnost změnit dle cesty k libovolnému txt souboru i místo uložení komprimovaného textu

## Ostatní poznámky
- Program pracuje s českými znaky díky nastavení kódování na Encoding.UTF8.
- Cesty k souborům jsou konfigurovány v konfiguračním souboru a logy jsou ukládány ve formátu JSON.
- Program obsahuje ochranu před chybami a zachycuje výjimky, které jsou zaznamenány v logu.
- Uživatelské rozhraní nabízí uživateli snadné ovládání programu.
