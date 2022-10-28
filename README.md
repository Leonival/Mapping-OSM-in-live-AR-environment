# what is this?
This is a demo solution for the OSS4SDG - Sustainable Smart Cities, Challenge # 2 – Development of apps based on OSM data (https://ideas.unite.un.org/sdg11/Page/Challenge2)

Acknowledged to SnakeSneakS source code (https://github.com/SnakeSneakS/OpenStreetMap-Unity) and Sloan Kelly with the Youtube tutorial GTA in Unity!? Use Real World Maps! (https://www.youtube.com/watch?v=780Ia5e8LHQ) and the source code (https://github.com/codehoose/real-world-map-data).

# Idea
The general idea is we hope to navigate in AR environment based on OSM 3D data. Step by step, we plan to
1. Collect the height infomation of buildings and upload them into OSM. （Ongoing）
2. Download the OSM data and create a 3D model in unity. (Fork and Developing)
3. Developing the AR app in Microsoft HoloLens 2 with Mixed Reality Toolkit. (Demo pending)
4. Connecting the live coordinate data in mobile phone with the HoloLens, based on the blue tooth. (Completed)
5. Georeferencing the coordinate from the real world to unity. (Ongoing)
6. Creating the navigated interaction in HoloLens. (Pending)

# Data
Open data includes
  - Building Height 2012 from Copernicus Land Monitoring Service (https://land.copernicus.eu/local/urban-atlas/building-height-2012)
  - Ordnance Survey MasterMap Building Height Attribute (https://www.ordnancesurvey.co.uk/business-government/products/mastermap-building).  

Both of them are raster data.  
Our team also collects building height data from SAR data. Paper name:  
  - Large-scale building height retrieval from single SAR imagery based on bounding box regression networks (https://www.sciencedirect.com/science/article/pii/S0924271621003221)  
  - CG-Net: Conditional GIS-Aware Network for Individual Building Segmentation in VHR SAR Images (https://ieeexplore.ieee.org/abstract/document/9321533)  
PS. The building height is not validated currently. Thus we haven't updated the data to OSM.

# How
1. Download map data (.osm file) from JOSM, an extensible editor for OpenStreetMap (https://josm.openstreetmap.de/). Download the data from website is not recommended, it might cause some error when rendering in unity.

2. Put the .osm file in Assets/OSM/Data/

3. In SampleScene, Find the component <MapController> atacched to gameobject "OSMmap", change its OSMfileName value. If you named your .osm file as "name.osm", you shoude enter "name.osm". 

4. Open the scene document. Click the plan button to render the view.

5. Build the app with the Mixed Reality Toolkit.

6. Adjust and correct the position data in OSM, Mobile phone, and unity into the same coordinate system.


# Study area:
Main campus, Technical University of Munich.
![OSM](https://github.com/Leonival/Mapping-OSM-in-live-AR-environment/blob/286710b06e4cb9e8bf2aeba18fc55650860181a9/Assets/OSM%20of%20TUM.png)
![unity](https://github.com/Leonival/Mapping-OSM-in-live-AR-environment/blob/0ffd786200677f49d7f451300256f6fda7cf7895/OSM%20in%20Munich.png)

# License: 
[OpenStreetMap](https://www.openstreetmap.org/copyright/)
- © OpenStreetMap contributors
- Base map and data from OpenStreetMap and OpenStreetMap Foundation
- [Open Data Commons Open Database License](https://opendatacommons.org/licenses/odbl/)
- [Creative Commons Attribution-ShareAlike 2.0](https://creativecommons.org/licenses/by-sa/2.0/)
