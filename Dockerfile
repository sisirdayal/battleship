FROM mcr.microsoft.com/dotnet/runtime:6.0

COPY /Battleship.Ascii/bin/Release/net6.0/publish ./app

ENTRYPOINT ['dotnet','Battleship.Ascii.dll']
