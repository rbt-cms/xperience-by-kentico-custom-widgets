# Xperience by Kentico Custom Widget - Google Map
It displays map obtained from the Google maps service using Latitude,Longitude and Google API Key

# Installation

Install the Kentico.Xperience.Custom.Widgets.GoogleMap.1.0.0 NuGet Package to your Xperience by Kentico website (>=29.4.0 with .Net 8.0) and rebuild the project.

# Widget

Thisis a widget which allows you to add a Google Map to your page with certain attributes that can be configured while adding. The properties that can be configured are:

- IsVisible: Select IsVisible option to show/hide widget on page
- Latitude*: Enter desired Latitude
- Longitude*: Enter desired Longitude
- Content Before: HTML content placed before the widget content. Can be used to display a header or add encapsulating code such as div tag
- Content After: HTML content placed after the widget content. Can be used to display a header or add encapsulating code such as div tag

*Required fields

Note: Make sure to insert your Google Maps API token into appSettings.json:
<code>"GoogleMapsApiKey":"{key}"
</code>

# Author

This custom widget was created by Ray Business Technologies Pvt Ltd.
Last updated 28-02-2025

# License

This widget is provided under MIT license.

# Uninstall

Uninstall this from the NuGet Package Manager and rebuild the project.

# Reporting issues

Please report any issues seen, in the issue list. We will address at the earliest possibility.

# Compatibility

This widget has been tested on Xperience by Kentico version (29.5.2) and can be used on >=29.4.0 with .Net 8.0. 
