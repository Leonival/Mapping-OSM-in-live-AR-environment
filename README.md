# what is this?
This is a demo solution for the OSS4SDG - Sustainable Smart Cities, Challenge # 2 – Development of apps based on OSM data (https://ideas.unite.un.org/sdg11/Page/Challenge2)

Acknowledged to SnakeSneakS source code (https://github.com/SnakeSneakS/OpenStreetMap-Unity) and Sloan Kelly with the Youtube tutorial GTA in Unity!? Use Real World Maps! (https://www.youtube.com/watch?v=780Ia5e8LHQ) and the source code (https://github.com/codehoose/real-world-map-data).

# Idea
The general idea is we hope to navigate in AR environment based on OSM 3D data. Step by step, we plan to
1. Collect the height infomation of buildings.
2. Download the OSM data and create a 3D model in unity with the OSM data. This function is a fork by OpenStreetMap-Unity. We promote the style and environment of that.
3. Developing the AR app in Microsoft HoloLens 2
4. 

# How:
1. Open data includes 1. Building Height 2012 from Copernicus Land Monitoring Service (https://land.copernicus.eu/local/urban-atlas/building-height-2012) and 2. Ordnance Survey MasterMap Building Height Attribute (https://www.ordnancesurvey.co.uk/business-government/products/mastermap-building). Both of them are raster data. Our team also collects building height data from SAR data. Paper name: Large-scale building height retrieval from single SAR imagery based on bounding box regression networks
  PS. The building height is not validated currently. Thus we haven't updated the data to OSM and use this data for OSS4SDG
2. Download map data (.osm file) from JOSM, an extensible editor for OpenStreetMap (https://josm.openstreetmap.de/). Download the data from website is not recommended, it might cause some error when rendering in unity.
3. Put the .osm file in Assets/OSM/Data/
4. In SampleScene, Find the component <MapController> atacched to gameobject "OSMmap", change its OSMfileName value. If you named your .osm file as "name.osm", you shoude enter "name.osm". 

# Study area:
Main campus, Technical University of Munich.

# License: 
[OpenStreetMap](https://www.openstreetmap.org/copyright/)
- © OpenStreetMap contributors
- Base map and data from OpenStreetMap and OpenStreetMap Foundation
- [Open Data Commons Open Database License](https://opendatacommons.org/licenses/odbl/)
- [Creative Commons Attribution-ShareAlike 2.0](https://creativecommons.org/licenses/by-sa/2.0/)
