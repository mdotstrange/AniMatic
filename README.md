# AniMatic

* To use this script drop it into an "Editor" folder in your project
* This script works with Unity Standard Shaders because the other render pipelines are a mess 0_0

* Select one or more folders that contain pbr textures with a standard naming structure and use the folder method
* ![](https://github.com/mdotstrange/AniMatic/raw/main/folders.gif)

* || or ||

* Select some pbr textures then access the script using the Right Click menu
* ![](https://github.com/mdotstrange/AniMatic/raw/main/AutoMat.gif)

* It will load the textures into the correct channels on the new material
* ![](https://github.com/mdotstrange/AniMatic/raw/main/CTUEWA5.png)

* To customize the script for your texture naming change the names of the strings with the comments

<  if(item.name.Contains("Base_Color") || item.name.Contains("Albedo")) >

* So if your albedo files are just named "Color" chage the "Base_Color" to "Color"
* You can add as many words to match just add another ||
* Do this with the rest of the channels

* YEH YEH its still faster then without this script maaaaaaaaaaan
     
         
