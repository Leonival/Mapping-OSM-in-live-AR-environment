# what is this?
This is a demo solution for the OSS4SDG - Sustainable Smart Cities, Challenge # 2 – Development of apps based on OSM data (https://ideas.unite.un.org/sdg11/Page/Challenge2)

Acknowledged to SnakeSneakS source code (https://github.com/SnakeSneakS/OpenStreetMap-Unity) and Sloan Kelly with the Youtube tutorial GTA in Unity!? Use Real World Maps! (https://www.youtube.com/watch?v=780Ia5e8LHQ) and the source code (https://github.com/codehoose/real-world-map-data).

#Idea
The general idea is navig

# How:
1. Download map data (.osm file) from JOSM, an extensible editor for OpenStreetMap (https://josm.openstreetmap.de/). Download the data from website is not recommended, it might cause some error when rendering in unity.
2. Put the .osm file in Assets/OSM/Data/
3. In SampleScene, Find the component <MapController> atacched to gameobject "OSMmap", change its OSMfileName value. If you named your .osm file as "name.osm", you shoude enter "name.osm". 


# License: 
[OpenStreetMap](https://www.openstreetmap.org/copyright/)
- © OpenStreetMap contributors
- Base map and data from OpenStreetMap and OpenStreetMap Foundation
- [Open Data Commons Open Database License](https://opendatacommons.org/licenses/odbl/)
- [Creative Commons Attribution-ShareAlike 2.0](https://creativecommons.org/licenses/by-sa/2.0/)
