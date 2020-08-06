# 1-to-1 RTC: A Sample Web App using C# and EnableX Web Toolkit

The Sample Web App demonstrates the use of APIs for EnableX platform to carry out 1-to-1 RTC (Real Time Communication). The main motivation behind this application is to demonstrate usage of APIs and allow developers to ramp up on app by hosting on their own devices instead of directly using servers.

RTC Applications hosted on EnableX platform run natively on supported set of web browsers without any additional plugin downloads. 

This basic 1-to-1 Video Chat Application is developed using C#, HTML, CSS, Bootstrap, JAVA Script, jQuery and EnxRtc (The EnableX Web Toolkit). 

>The details of the supported set of web browsers can be found here:
https://developer.enablex.io/video/faqs/device-browser-support/#q2



## 1. Important!

When developing a Client Application with EnxRtc.js make sure to include the updated EnxRtc.js polyfills for RTCPeerConnection and getUserMedia otherwise your application will not work in web browsers.



## 2. Demo

Visit Demo Zone (https://try.enablex.io/) to request a Guided Demo or Demo Access to different type of application available there. 



## 3. Installation


### 3.1 Pre-Requisites

#### 3.1.1 App Id and Api Key 

* Register with EnableX [https://portal.enablex.io/trial-sign-up/] 
* Create your Application
* Get your App ID and App Key delivered to your Email
* Clone or download this Repository [https://github.com/EnableX/One-to-One-Video-Calling-C-Sharp-Application] & follow the steps further

#### 3.1.2 SSL Certificates

The Application needs to run on https. So, you need to use a valid SSL Certificate for your Domain and point your application to use them.


#### 3.1.3 Configure

Before you you try accessing the application using Browser, configure the API Service by editing `appsettings.json' file to meet your requirement:
``` 
"EnableX": {
    "API_URL": "https://api.enablex.io/v1/",
    "APP_ID": "YOUR_APP_ID",
    "APP_KEY": "YOUR_APP_KEY"
}
```


### 3.2 Test video call

* Open a browser and go to [https://yourdomain.com:{PORT}/](https://yourdomain.com:{PORT}/). The browser should load the App. 
* You need `Room ID` to join. We have added a `Don't have a Room ID? Create One` link below the form. Click it to get a Room-Id prefilled in the form.
* Store the `Room ID` for future use and to share it
* Enter a user `Name` (e.g. test0)
* Select `Join as Moderator`
* `Sign In` and allow access to camera and microphone when prompted to start your first webRTC call through EnableX
* Open another browser tab and enter [https://yourdomain.com:{PORT}/](https://yourdomain.com:{PORT}/)
* Enter the same `Room ID` previously created, add a different user `Name` (e.g. test1) and select `Join as Participant` and click `Sign In`
* Now, you should see your own video in both the tabs!


### 3.3 Test screen share

* Once video call started, click on 'Desktop' icon to start screen share.
* Once screen share started, layout for the presenter remain same (side by side video). However screen which is shared by presentor, is displayed to the person on other side by hiding the previous layout (side by side video).
* Click on 'Desktop' icon to again to stop screen share.



### 4 List of API endpoints exposed by the application

* POST https://yourdomain.com:{PORT}/api/create-room                 - It creates EnableX Room for Video Communication
* GET  https://yourdomain.com:{PORT}/api/get-room/?roomId={roomId}   - Get details of the room {roomId} created by calling /api/create-room 
* POST https://yourdomain.com:{PORT}/api/create-token                - Create EnableX token for Video Communication
    Params -
    ```
    {
        "name": "XXXX",      // Name of the user who is creating token to join session
        "role": "XXXX",      // Role of User. Values: moderator, participant (All in lowercase)
        "user_ref": "XXXX",  // User ID or Reference. You may use it from your Information System. Post Call Reports include this data for your reference/reporting
        "roomId": "XXXX"     // room id created by calling /api/create-room 
    }
    ```



## 5 Server API

EnableX Server API is a Rest API service meant to be called from Partners' Application Server to provision video enabled 
meeting rooms. API Access is given to each Application through the assigned App ID and App Key. So, the App ID and App Key 
are to be used as Username and Password respectively to pass as HTTP Basic Authentication header to access Server API.
 
For this application, the following Server API calls are used: 
* https://developer.enablex.io/video-api/server-api/rooms-route/#get-room-info - To get a complete room definition of a given Room
* https://developer.enablex.io/video-api/server-api/rooms-route/#create-room - To create a room
* https://developer.enablex.io/video-api/server-api/rooms-route/#create-token - To create Token for the given Room

To know more about Server API, go to:
https://developer.enablex.io/video-api/server-api/rooms-route/



## 6 Client API

Client End Point Application uses Web Toolkit EnxRtc.js to communicate with EnableX Servers to initiate and manage RTC Communications.  

To know more about Client API, go to:
https://developer.vcloudx.com/video/downloads/#web-toolkit
