FROM aspnet
RUN mkdir C:\randomanswers

RUN powershell -NoProfile -Command \
    Import-module IISAdministration; \
    New-IISSite -Name "ASPNET" -PhysicalPath C:\randomanswers -BindingInformation "*:8000:"

EXPOSE 8000

ADD containerImage/ /randomanswers
