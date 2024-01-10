# Popis programu
Program je konzolová aplikace napsaná v jazyce C#, která provádí kompresi textového souboru odstraněním samohlásek ze slov. Program také umožňuje uživateli manipulovat s vstupními a výstupními soubory a spravovat místo, kam jsou ukládány.

## Způsob použití
1. Uživatel extrahuje zip soubor.
2. Následně spustí exe soubor, který se nachází zde: TxtCompression\bin\Debug\net6.0\TxtCompression.exe.
3. Program by měl být zaplý a můžete si libovolně vybrat možnosti 0-5 dle libosti.
4. Složka data se používá pro jednoduchý výběr dat např. => data/input.txt
5. Složka log obsahuje logs.json soubor, který ukládá všechny změny
6. Složka config obsahuje soubor config.cfg, kde si program bere text na začátku programu, lze jednoduše změnit
   - (pokud máte textový soubor mimo složku data, je potřeba uvést cestu k souboru (podobně jako v bodu 2.))

   ![image](https://github.com/MichalStilec/Komprimator/assets/113086016/6cdb199a-6e4d-41fe-8ba1-2217d102ac8b)

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
  
  ![image](https://github.com/MichalStilec/Komprimator/assets/113086016/03796279-6aed-4507-bf89-b05e1bbbe581)

  
### Metoda RemoveVowelsFromWords
- Rozděluje text na slova.
- Odstraňuje samohlásky ze slov.
- Vrací modifikovaný text.

  ![image](https://github.com/MichalStilec/Komprimator/assets/113086016/18408d80-49e2-418a-94ad-9410f8ef76fb)

### Metoda RemoveVowels
- Odstraňuje samohlásky ze zadaného řetězce.
- Vrací modifikovaný řetězec.

  ![image](https://github.com/MichalStilec/Komprimator/assets/113086016/ee21e7a2-80b9-48e7-a40c-4ac09688bab4)

## Třída Config

### Metoda LoadInput a LoadResult
- Načítá cestu k vstupnímu/výslednému souboru z konfiguračního souboru.
- Kontroluje existenci souboru.
- Vrací načtenou cestu nebo výchozí hodnotu.

  ![image](https://github.com/MichalStilec/Komprimator/assets/113086016/ed7c78ad-6f1b-4199-8200-b8d092ccd126)


## Třída Logs
### Metoda LogSuccess
- Zaznamenává úspěšné zprávy do logu ve formátu JSON.
### Metoda LogFail
- Zaznamenává neúspěšné zprávy do logu ve formátu JSON.
### Metoda LogError
- Zaznamenává chyby do logu ve formátu JSON.

  ![image](https://github.com/MichalStilec/Komprimator/assets/113086016/1ab9fbfd-277a-4821-b7c5-7fcf8857db4d)

  
## Jak měnit soubory
1. Program načte konfiguraci ze souboru TxtCompression\bin\Debug\net6.0\config\config.cfg, zde si můžete změnit počáteční soubory.
2. Program také může načíst soubor dle cesty k vámi zadanému souboru, pro tuto možnost zmáčkněte 2 na začátku programu a cestu uvádějte **bez úvozovek!**

![image](https://github.com/MichalStilec/Komprimator/assets/113086016/41c92c5b-7a1d-4b3c-9f16-14e722a2fdc2)

   
4. Program má taky možnost změnit dle cesty k libovolnému txt souboru i místo uložení komprimovaného textu

## Ostatní poznámky
- Program pracuje s českými znaky díky nastavení kódování na Encoding.UTF8.
- Cesty k souborům jsou konfigurovány v konfiguračním souboru a logy jsou ukládány ve formátu JSON.
- Program obsahuje ochranu před chybami a zachycuje výjimky, které jsou zaznamenány v logu.
- Uživatelské rozhraní nabízí uživateli snadné ovládání programu.

## Program byl otestován spolužáky
![image](https://github.com/MichalStilec/Komprimator/assets/113086016/325b4ed2-46fa-42b6-aed3-9b99ad80b159)

![image](https://github.com/MichalStilec/Komprimator/assets/113086016/9ecc1bd3-fb01-4611-929d-e26383956c2b)

![image](https://github.com/MichalStilec/Komprimator/assets/113086016/dfe0fec2-2358-4c5a-8a01-81fd92fc1b34)



