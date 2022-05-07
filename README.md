# DacaSoft.MsBuildLoggerEvents

Soluzione usata con una serie di Custom Events nel fare le Build di una Soluzione o Programma.

Un esempio molto più completo di CustomEvetnsLogger lo si può trovare in https://github.com/JetBrains/teamcity-msbuild-logger 
che usa il CI di TeamCity per tracciare la fase di build in Visual Studio.

Sono presenti 4 Tipi di Custom Logger.

    Progetto MsBuildLoggeerEvents.csproj

    FileLoggerEvents    (previsto per file di log su txt)
    CsvLoggerEvents     (previsto per file csv sotto eventi di warnings)
    GitHubLoggerEvents  (previsto in fase di build su GitHub ci guarda BuilderGitHubLogger.md per maggiori dettagli)
    ConsoleLoggerEvents (previsto per tracciare a console in tempo reale la build)*

    ** Per la Console sono previste delle Categorie e configurazioni di log, un esempio da mettere 
       nel .config del progetto da buildare è nel nodo xml "ConsoleLoggerEvents.config".

Esempi di uso per buildare con questi custom Build.:

    #!bat msbuild.exe [...] /logger:MinimalConsoleLogger,CodehulkNET.MSBuild.Loggers.dll;minimalConsoleLogger.config

    -- Per la ConsoleLogger ci sono argomenti opzionali, specificatine nel file di configurazione.
       #!bat msbuild.exe [...] /logger:BuilderConsoleLogger,DacaSoft.MSBuildLoggerEvents.dll;ConsoleLoggerEvents.config

    -- Il CSVWarningsLogger eccetto il nome per l'output file sono argomenti mandatori.
      #!bat msbuild.exe [...] /logger:BuilderCsvLogger,DacaSoft.MSBuildLoggerEvents.dll;warnings.csv
