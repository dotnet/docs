mkdir buildimage
docker save -o "$(Build.Repository.LocalPath)/buildimage" "buildimage-$(Build.BuildNumber)"
