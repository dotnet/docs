        ' SiteMapProvider and StaticSiteMapProvider methods that this derived class must override.
        '
        ' Clean up any collections or other state that an instance of this may hold.
        Protected Overrides Sub Clear()
            SyncLock Me
                aRootNode = Nothing
                MyBase.Clear()
            End SyncLock
        End Sub 'Clear