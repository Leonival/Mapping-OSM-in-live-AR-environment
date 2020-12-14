I tried to create 3d town with using [OpenStreetMap](https://wiki.openstreetmap.org/wiki/Main_Page)

![one image](8F5308E0-978E-42EE-BF78-81F121E8EFD1_1_201_a.jpeg)


How:
1. Download map data (.osm file) from [this web site](https://www.openstreetmap.org/)
2. Put the .osm file in Assets/OSM/Data/ Folder (important)
3. In SampleScene, Find the component <MapController> atacched to gameobject "OSMmap", change its OSMfileName value. If you named your .osm file as "name.osm", you shoude enter "name.osm". 



Now:
1. Show Roads
2. Show Buildings
3. Show Parks

- Both of them are assigned one material
- Their location is real-based, but their color and look are not real-based.# 
