FROM microsoft/windowsservercore

# Install IIS and some optional features
RUN dism /online /enable-feature /featurename:IIS-WebServerRole \
                                 /featurename:IIS-WebServer \
                                 /featurename:IIS-CommonHttpFeatures \
                                 /featurename:IIS-StaticContent \
                                 /featurename:IIS-DefaultDocument \
                                 /featurename:IIS-DirectoryBrowsing \
                                 /featurename:IIS-HttpErrors \
                                 /featurename:IIS-ApplicationDevelopment \
                                 /featurename:IIS-CGI \
                                 /featurename:IIS-HealthAndDiagnostics \
                                 /featurename:IIS-HttpLogging \
                                 /featurename:IIS-Security \
                                 /featurename:IIS-RequestFiltering \
                                 /featurename:IIS-Performance \
                                 /featurename:IIS-HttpCompressionStatic \
                                 /featurename:IIS-WebServerManagementTools

ADD ServiceMonitor.exe /ServiceMonitor.exe

ENTRYPOINT ["C:\\ServiceMonitor.exe", "w3svc"]

RUN powershell -Command Add-WindowsFeature NET-Framework-45-ASPNET
RUN powershell -Command Add-WindowsFeature Web-Asp-Net45

