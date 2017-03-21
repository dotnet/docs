        <!-- The AdRotator control -->
        <mobile:AdRotator id="AdControl" runat="server"
            ImageKey="MobileImgSrc" NavigateUrlKey="TargetUrl"
            AdvertisementFile="App_Data/ads.xml" Alignment="Left" 
            KeywordFilter="Developer" OnAdCreated="AdCreated_Event">
            <DeviceSpecific>
                <Choice Filter="isWML11" NavigateUrlKey="WmlTargetUrl" 
                    ImageKey= "WmlImageSrc" />
            </DeviceSpecific>
        </mobile:AdRotator>