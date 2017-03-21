           int waitingUpgradeableReadCt = rwLock.WaitingUpgradeCount;
           if (waitingUpgradeableReadCt > UPGRADEABLEREAD_THRESHOLD)
           {
               performanceLog.WriteEntry(String.Format(
                   "{0} blocked upgradeable reader threads; exceeds recommended maximum.", 
                   waitingUpgradeableReadCt));
           }