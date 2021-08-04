Клиент - UtisTestTask.Client  
Сервис gRPC - UtisTestTask.Service  
  
При Запуске Клиента Автоматически запускается Сервис.  

.proto файл находятся в UtisTestTask.ServiceContract, я сгенерировал WorkerStream.cs и WorkerStreamGrpc.cs файлы вручнуя, с помошю комманды:  
packages\Grpc.Tools.2.39.0-pre1\tools\windows_x86\protoc.exe -I UtisTestTask.ServiceContract\Protos --csharp_out UtisTestTask.ServiceContract\Protos UtisTestTask.ServiceContract\Protos\WorkerStream.proto --grpc_out UtisTestTask.ServiceContract\Protos --plugin=protoc-gen-grpc=packages\Grpc.Tools.2.39.0-pre1\tools\windows_x86\grpc_csharp_plugin.exe  

во ViewModels я использовал один и тот же Модель (энтити), для экономия времени, хотя знаю что надо добавить дто и врапперс для трекинга изминиений и соответсвенно AutoMapper для конвертации с одного типа на дргой.

Connection string: .\sqlexpress

