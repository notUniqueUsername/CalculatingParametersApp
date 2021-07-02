RD /s /q Papp
DEL ParamApp.zip
MD Papp
COPY CalculatingParametersApp\ParametersApp\bin\Release\ParametersApp.exe Papp\ParametersApp.exe 
COPY CalculatingParametersApp\ParametersApp\bin\Release\CalculatingParametersLib.dll Papp\CalculatingParametersLib.dll
COPY CalculatingParametersApp\ParametersApp\bin\Release\MathNet.Numerics.dll Papp\MathNet.Numerics.dll
COPY CalculatingParametersApp\ParametersApp\bin\Release\ZedGraph.dll Papp\ZedGraph.dll
COPY Version.txt Papp\Version.txt
D:\1\WinRAR\WinRAR.exe A -m5 -ep ParamApp.zip Papp