           Dim waitingUpgradeableReadCt As Integer = rwLock.WaitingUpgradeCount
           If waitingUpgradeableReadCt > UPGRADEABLEREAD_THRESHOLD Then
               performanceLog.WriteEntry(String.Format( _
                   "{0} blocked upgradeable reader threads; exceeds recommended maximum.", _
                   waitingUpgradeableReadCt))
           End If