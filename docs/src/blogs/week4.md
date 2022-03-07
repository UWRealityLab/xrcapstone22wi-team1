# Week 4 (1/31 - 2/6)

## Summary
We created more materials and added lighting/shading to make the building model more realistic. We  imported the Dubs model to the scene and created scripts for Dubs to make it follow the user when the user moving around in the building. We also created the UI for the Interactive Wall and added the content that will be displayed on the interface. 

## New Features
- More detailed textures and materials applied on the building model.
- Added lighting and shading to the model.
- Added Graduation, Research, Faculty, and Course info on the Interactive wall.
- Allowed Dubs to follow and turn with player.

## Files to Reviews
- CSE2 building model (`Scene/Main.unity`)
- Dubs model
    - `cse2VirtualTour/Assets/Scripts/Dubs/FollowerPalyer.cs`
    - `cse2VirtualTour/Assets/Scripts/Dubs/TurnWithPlayer.cs`
    - `cse2VirtualTour/Assets/Dubs/FBX/Husky_AContr_Demo.controller`
- Interactive wall interface (`Scene/Main.unity`)

## Blocking Issues

- Images will be blurred when users are not close enough to the image


## Individual Updates

- Jolin
    - Exported the texturified building model from Blender to Unity
    - Created special materials for the building components (eg. glass, steel, conrete, etc.)
    - Added lighting and shading to the model (eg. directional lights, point lights, etc.)
- Justin
    - Added CSE information on the interactive wall (graduation, research, faculty, courses)
- Peter
    - Allowed the Dubs to follow the user and stick in front of the user
    - Allowed the Dubs to turn with the user whenever user either turn with the headset or controller.
    - Added XR interaction tools to allow user to deploy application on quest.