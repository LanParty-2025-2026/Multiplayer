## Managing of multiplayer
This repo contains the basic logic for managing multiplayer.

# References
[unityDocs](https://docs.unity3d.com/Packages/com.unity.netcode.gameobjects@2.7/manual/tutorials/get-started-with-ngo.html)

# Steps for reaching this point
1. Installing netcode for gameobjects
   In the package manager choose Install By name and copy this line
   
   com.unity.netcode.gameobjects 
2. Prepare client-server
   Create the Network manager component (create empty)
   Add the component network manager to the component previously created
   Select the unity transport
3. Remember to save by pressing Ctrl + S
4. Create a player to spawn every time a pc connects