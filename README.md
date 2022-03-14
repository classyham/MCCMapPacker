
# MCC Map Packer

A tool to ease the creation and installation of custom or modded maps for Halo: The Master Chief Collection.
The code is a mess at current but fully functional. I will be tidying it in the future and will support any pull requests that actively make the tool better.




## Features

- Extracts archives into the game directory (backing up stock maps as it goes)
- Validates all playable maps against the stock with filters per game
- Allows easy creation of archives with user-specified maps, renaming, and creating directories as needed inside the archive.
- Easy to Use GUI, no command line or messing with game files needed.
- Restores stock maps from backups created by the tool.

## How to Use

- Extract the software
- Run "MCCMapPacker.exe"
- Fill out your game path if prompted
- If you already have a pack to install, click "Load Pack" and navigate to the pack zip. 
- To create a pack, click "Create Pack"
- On this screen, you can select games and maps from the dropdowns on the left
- Click "Add Map" to add the selected map to the list in the centre
- To assign a map to override, click on the map name in the centre, then click "Override Selected"
- Browse to your map and select it, this should change "No map selected" to the name of the map you just selected.
- Repeat for all needed maps
- Input a pack name in the top text field
- Click "Create Pack" (NOTE: This may take some time depending on how many maps you are packing as well as the size of the maps)
- Once the progress bar has disappeared and the buttons are enabled again, your map pack zip will be in the "Output Directory" which you can access by clicking the "Open Output Folder" button 
- Share the pack with your friends and enjoy!

## Online Connectivity

As of version 0.0.2 the tool can now connect to the internet ONLY if the user accepts the prompt to do so. The only url it accesses is: [Girhub Raw - StockMapData.Json](https://raw.githubusercontent.com/classyham/MCCStockMapHashes/main/StockMapData.json)

The tool can check for updates but this is done by testing against the build_tag.txt inside of the MCC install directory. This will prompt the user whether they would like to auto update the json file from the link above, but this can be replaced manually if preferred. 

## MD5Builder
MD5Builder is not needed for release builds. It is an internal tool that automatically generates StockMapData.json to be used when the MCC updates. I have included the source for those who want to look at it, but it is not needed to be used by end users.

## Authors

- [@classyham - Twitter](https://twitter.com/Classyham)


## License

[AGPL](https://www.gnu.org/licenses/agpl-3.0.en.html)

![https://www.gnu.org/licenses/agpl-3.0.en.html](https://www.gnu.org/graphics/agplv3-with-text-162x68.png)


## Thanks
- [R93 Sniper](https://twitter.com/R93_Sniper) - Helped me get Mapfiles to Map Names
- [DotNetZip](https://github.com/haf/DotNetZip.Semverd) - For the awesome Zip library
