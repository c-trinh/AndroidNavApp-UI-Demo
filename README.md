# CptS_484_Navigation_App

Navigation app for the blind. This app will feature voice commands and output to guide the vision impaired population through buildings. 

To make a new feature first  

git checkout staging (dont branch from master)  
git checkout -b Feature-name  
	i.e "git checkout -b New_Cool_Ui_Element  
  
git push --set-upstream origin branch-name  
	i.e "git push --set-upstream origin New_Cool_Ui_Element 
  
[ *Make changes to your source code* ]  
  
git status (check that you saved the files)  
  
git add <file you made changes to>  
	i.e git add src/ui/cool_new_element  
  
git commit -m "short direct message describing changes"  
	i.e git commit -m "changed click event"  
    
git push 
  
[ *keep doing this until feature is functional* ]  
  
on the gitlab dashboard (easiest method), navigate to your branch, select merge request, TARGET BRANCH IS STAGING NOT MASTER YOU MIGHT AHVE TO MANUALLY SELECT THIS, assign to whoever, select milestone 2, select a label (if one isnt there make one), then submit merge request  
  
If the merge request can be automatically merged you can do it  
If the merge needs to be mmanually done you can do it on the browser or follow the exact commands it tells you to.  
  
if manually done the code will look like  
  
<=====Branch====>  
new code  
new code  
new code  
<======Branch===>  
<=====Head====>  
old code  
old code  
old code  
<=====Head=====>  
  
To make the merge request accepted, just delete whichever code is not wanted  
once all the <=====> labels are gone the merge will be accepted.   

