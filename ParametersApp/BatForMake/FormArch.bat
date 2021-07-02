copy Version.txt ..\Version.txt
cd ..
RD /s /q ..\..\..\..\Papp
DEL ..\..\..\..\ParamApp.zip
MD ..\..\..\..\Papp

COPY ParametersApp.exe ..\..\..\..\Papp\ParametersApp.exe 
COPY CalculatingParametersLib.dll ..\..\..\..\Papp\CalculatingParametersLib.dll
COPY MathNet.Numerics.dll ..\..\..\..\Papp\MathNet.Numerics.dll
COPY ZedGraph.dll ..\..\..\..\Papp\ZedGraph.dll
COPY Version.txt ..\..\..\..\Papp\Version.txt
cd ..\..\..\..\
D:\1\WinRAR\WinRAR.exe A -m5 -ep ParamApp.zip Papp