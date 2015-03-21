[1mdiff --git a/app/src/main/java/com/example/android/sunshine/app/ForecastFragment.java b/app/src/main/java/com/example/android/sunshine/app/ForecastFragment.java[m
[1mindex d6de41d..2e611d2 100644[m
[1m--- a/app/src/main/java/com/example/android/sunshine/app/ForecastFragment.java[m
[1m+++ b/app/src/main/java/com/example/android/sunshine/app/ForecastFragment.java[m
[36m@@ -1,3 +1,18 @@[m
[32m+[m[32m/*[m
[32m+[m[32m * Copyright (C) 2014 The Android Open Source Project[m
[32m+[m[32m *[m
[32m+[m[32m * Licensed under the Apache License, Version 2.0 (the "License");[m
[32m+[m[32m * you may not use this file except in compliance with the License.[m
[32m+[m[32m * You may obtain a copy of the License at[m
[32m+[m[32m *[m
[32m+[m[32m *      http://www.apache.org/licenses/LICENSE-2.0[m
[32m+[m[32m *[m
[32m+[m[32m * Unless required by applicable law or agreed to in writing, software[m
[32m+[m[32m * distributed under the License is distributed on an "AS IS" BASIS,[m
[32m+[m[32m * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.[m
[32m+[m[32m * See the License for the specific language governing permissions and[m
[32m+[m[32m * limitations under the License.[m
[32m+[m[32m */[m
 package com.example.android.sunshine.app;[m
 [m
 import android.os.AsyncTask;[m
[36m@@ -20,18 +35,15 @@[m [mimport java.io.InputStreamReader;[m
 import java.net.HttpURLConnection;[m
 import java.net.URL;[m
 import java.util.ArrayList;[m
[32m+[m[32mimport java.util.Arrays;[m
 import java.util.List;[m
 [m
 /**[m
[31m- * A placeholder fragment containing a simple view.[m
[31m- * <p/>[m
[31m- * Created by justinas on 15.3.21.[m
[32m+[m[32m * Encapsulates fetching the forecast and displaying it as a {@link ListView} layout.[m
  */[m
 public class ForecastFragment extends Fragment {[m
 [m
[31m-[m
[31m-    ArrayAdapter<String> mForecastAdapter;[m
[31m-[m
[32m+[m[32m    private ArrayAdapter<String> mForecastAdapter;[m
 [m
     public ForecastFragment() {[m
     }[m
[36m@@ -39,19 +51,21 @@[m [mpublic class ForecastFragment extends Fragment {[m
     @Override[m
     public void onCreate(Bundle savedInstanceState) {[m
         super.onCreate(savedInstanceState);[m
[32m+[m[32m        // Add this line in order for this fragment to handle menu events.[m
         setHasOptionsMenu(true);[m
     }[m
 [m
     @Override[m
     public void onCreateOptionsMenu(Menu menu, MenuInflater inflater) {[m
[31m-        inflater.inflate(R.menu.forecastfragmen, menu);[m
[32m+[m[32m        inflater.inflate(R.menu.forecastfragment, menu);[m
     }[m
 [m
     @Override[m
     public boolean onOptionsItemSelected(MenuItem item) {[m
[32m+[m[32m        // Handle action bar item clicks here. The action bar will[m
[32m+[m[32m        // automatically handle clicks on the Home/Up button, so long[m
[32m+[m[32m        // as you specify a parent activity in AndroidManifest.xml.[m
         int id = item.getItemId();[m
[31m-[m
[31m-        //noinspection SimplifiableIfStatement[m
         if (id == R.id.action_refresh) {[m
             return true;[m
         }[m
[36m@@ -62,36 +76,41 @@[m [mpublic class ForecastFragment extends Fragment {[m
     public View onCreateView(LayoutInflater inflater, ViewGroup container,[m
                              Bundle savedInstanceState) {[m
 [m
[31m-        List<String> forecastEntries = new ArrayList<>();[m
[31m-        forecastEntries.add("Today - Sunny - 9/8");[m
[31m-        forecastEntries.add("Tomorrow - Sunny - 9/8");[m
[31m-        forecastEntries.add("Sunday - Sunny - 9/8");[m
[31m-        forecastEntries.add("Monday - Sunny - 9/8");[m
[31m-        forecastEntries.add("Tuesday - Sunny - 9/8");[m
[31m-        forecastEntries.add("Wednesday - Sunny - 9/8");[m
[31m-        forecastEntries.add("Thursday - Sunny - 9/8");[m
[31m-        forecastEntries.add("Friday - Sunny - 9/8");[m
[31m-[m
[31m-        mForecastAdapter = new ArrayAdapter<String>(getActivity(),[m
[31m-                R.layout.list_item_forecast, R.id.list_item_forecast_textview, forecastEntries);[m
[32m+[m[32m        // Create some dummy data for the ListView.  Here's a sample weekly forecast[m
[32m+[m[32m        String[] data = {[m
[32m+[m[32m                "Mon 6/23 - Sunny - 31/17",[m
[32m+[m[32m                "Tue 6/24 - Foggy - 21/8",[m
[32m+[m[32m                "Wed 6/25 - Cloudy - 22/17",[m
[32m+[m[32m                "Thurs 6/26 - Rainy - 18/11",[m
[32m+[m[32m                "Fri 6/27 - Foggy - 21/10",[m
[32m+[m[32m                "Sat 6/28 - TRAPPED IN WEATHERSTATION - 23/18",[m
[32m+[m[32m                "Sun 6/29 - Sunny - 20/7"[m
[32m+[m[32m        };[m
[32m+[m[32m        List<String> weekForecast = new ArrayList<String>(Arrays.asList(data));[m
[32m+[m
[32m+[m[32m        // Now that we have some dummy forecast data, create an ArrayAdapter.[m
[32m+[m[32m        // The ArrayAdapter will take data from a source (like our dummy forecast) and[m
[32m+[m[32m        // use it to populate the ListView it's attached to.[m
[32m+[m[32m        mForecastAdapter =[m
[32m+[m[32m                new ArrayAdapter<String>([m
[32m+[m[32m                        getActivity(), // The current context (this activity)[m
[32m+[m[32m                        R.layout.list_item_forecast, // The name of the layout ID.[m
[32m+[m[32m                        R.id.list_item_forecast_textview, // The ID of the textview to populate.[m
[32m+[m[32m                        weekForecast);[m
 [m
         View rootView = inflater.inflate(R.layout.fragment_main, container, false);[m
 [m
[31m-        ListView listView = (ListView) rootView.findViewById(R.id.listView_forecast);[m
[32m+[m[32m        // Get a reference to the ListView, and attach this adapter to it.[m
[32m+[m[32m        ListView listView = (ListView) rootView.findViewById(R.id.listview_forecast);[m
         listView.setAdapter(mForecastAdapter);[m
 [m
[31m-[m
[31m-[m
[31m-[m
[31m-[m
         return rootView;[m
     }[m
 [m
[31m-    public static class FetchWeatherTask extends AsyncTask<Void, Void, Void> {[m
[32m+[m[32m    public class FetchWeatherTask extends AsyncTask<Void, Void, Void> {[m
 [m
         private final String LOG_TAG = FetchWeatherTask.class.getSimpleName();[m
 [m
[31m-[m
         @Override[m
         protected Void doInBackground(Void... params) {[m
             // These two need to be declared outside the try/catch[m
[36m@@ -104,7 +123,7 @@[m [mpublic class ForecastFragment extends Fragment {[m
 [m
             try {[m
                 // Construct the URL for the OpenWeatherMap query[m
[31m-                // Possible parameters are available at OWM's forecast API page, at[m
[32m+[m[32m                // Possible parameters are avaiable at OWM's forecast API page, at[m
                 // http://openweathermap.org/API#forecast[m
                 URL url = new URL("http://api.openweathermap.org/data/2.5/forecast/daily?q=94043&mode=json&units=metric&cnt=7");[m
 [m
[36m@@ -155,6 +174,4 @@[m [mpublic class ForecastFragment extends Fragment {[m
             return null;[m
         }[m
     }[m
[31m-[m
 }[m
[31m-[m
[1mdiff --git a/app/src/main/java/com/example/android/sunshine/app/MainActivity.java b/app/src/main/java/com/example/android/sunshine/app/MainActivity.java[m
[1mindex daaf500..e8729e7 100644[m
[1m--- a/app/src/main/java/com/example/android/sunshine/app/MainActivity.java[m
[1m+++ b/app/src/main/java/com/example/android/sunshine/app/MainActivity.java[m
[36m@@ -1,21 +1,24 @@[m
[32m+[m[32m/*[m
[32m+[m[32m * Copyright (C) 2014 The Android Open Source Project[m
[32m+[m[32m *[m
[32m+[m[32m * Licensed under the Apache License, Version 2.0 (the "License");[m
[32m+[m[32m * you may not use this file except in compliance with the License.[m
[32m+[m[32m * You may obtain a copy of the License at[m
[32m+[m[32m *[m
[32m+[m[32m *      http://www.apache.org/licenses/LICENSE-2.0[m
[32m+[m[32m *[m
[32m+[m[32m * Unless required by applicable law or agreed to in writing, software[m
[32m+[m[32m * distributed under the License is distributed on an "AS IS" BASIS,[m
[32m+[m[32m * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.[m
[32m+[m[32m * See the License for the specific language governing permissions and[m
[32m+[m[32m * limitations under the License.[m
[32m+[m[32m */[m
 package com.example.android.sunshine.app;[m
 [m
 import android.os.Bundle;[m
[31m-import android.support.v4.app.Fragment;[m
 import android.support.v7.app.ActionBarActivity;[m
[31m-import android.view.LayoutInflater;[m
 import android.view.Menu;[m
 import android.view.MenuItem;[m
[31m-import android.view.View;[m
[31m-import android.view.ViewGroup;[m
[31m-import android.widget.ArrayAdapter;[m
[31m-import android.widget.ListView;[m
[31m-[m
[31m-import java.io.BufferedReader;[m
[31m-import java.net.HttpURLConnection;[m
[31m-import java.util.ArrayList;[m
[31m-import java.util.List;[m
[31m-[m
 [m
 public class MainActivity extends ActionBarActivity {[m
 [m
[36m@@ -51,47 +54,4 @@[m [mpublic class MainActivity extends ActionBarActivity {[m
 [m
         return super.onOptionsItemSelected(item);[m
     }[m
[31m-[m
[31m-    /**[m
[31m-     * A placeholder fragment containing a simple view.[m
[31m-     */[m
[31m-    public static class ForecastFragment extends Fragment {[m
[31m-[m
[31m-        ArrayAdapter<String> mForecastAdapter;[m
[31m-        // These two need to be declared outside the try/catch[m
[31m-        // so that they can be closed in the finally block.[m
[31m-        HttpURLConnection urlConnection = null;[m
[31m-        BufferedReader reader = null;[m
[31m-[m
[31m-        // Will contain the raw JSON response as a string.[m
[31m-        String forecastJsonStr = null;[m
[31m-[m
[31m-        public ForecastFragment() {[m
[31m-        }[m
[31m-[m
[31m-        @Override[m
[31m-        public View onCreateView(LayoutInflater inflater, ViewGroup container,[m
[31m-                                 Bundle savedInstanceState) {[m
[31m-[m
[31m-            List<String> forecastEntries = new ArrayList<>();[m
[31m-            forecastEntries.add("Today - Sunny - 9/8");[m
[31m-            forecastEntries.add("Tomorrow - Sunny - 9/8");[m
[31m-            forecastEntries.add("Sunday - Sunny - 9/8");[m
[31m-            forecastEntries.add("Monday - Sunny - 9/8");[m
[31m-            forecastEntries.add("Tuesday - Sunny - 9/8");[m
[31m-            forecastEntries.add("Wednesday - Sunny - 9/8");[m
[31m-            forecastEntries.add("Thursday - Sunny - 9/8");[m
[31m-            forecastEntries.add("Friday - Sunny - 9/8");[m
[31m-[m
[31m-            mForecastAdapter = new ArrayAdapter<String>(getActivity(),[m
[31m-                    R.layout.list_item_forecast, R.id.list_item_forecast_textview, forecastEntries);[m
[31m-[m
[31m-            View rootView = inflater.inflate(R.layout.fragment_main, container, false);[m
[31m-[m
[31m-            ListView listView = (ListView) rootView.findViewById(R.id.listView_forecast);[m
[31m-            listView.setAdapter(mForecastAdapter);[m
[31m-[m
[31m-            return rootView;[m
[31m-        }[m
[31m-    }[m
 }[m
[1mdiff --git a/app/src/main/res/layout/fragment_main.xml b/app/src/main/res/layout/fragment_main.xml[m
[1mindex 0c27654..372b60d 100644[m
[1m--- a/app/src/main/res/layout/fragment_main.xml[m
[1m+++ b/app/src/main/res/layout/fragment_main.xml[m
[36m@@ -1,15 +1,17 @@[m
 <FrameLayout xmlns:android="http://schemas.android.com/apk/res/android"[m
[31m-    xmlns:tools="http://schemas.android.com/tools" android:layout_width="match_parent"[m
[31m-    android:layout_height="match_parent" android:paddingLeft="@dimen/activity_horizontal_margin"[m
[32m+[m[32m    xmlns:tools="http://schemas.android.com/tools"[m
[32m+[m[32m    android:layout_width="match_parent"[m
[32m+[m[32m    android:layout_height="match_parent"[m
[32m+[m[32m    android:paddingLeft="@dimen/activity_horizontal_margin"[m
[32m+[m
     android:paddingRight="@dimen/activity_horizontal_margin"[m
     android:paddingTop="@dimen/activity_vertical_margin"[m
     android:paddingBottom="@dimen/activity_vertical_margin"[m
[31m-    tools:context=".MainActivity$PlaceholderFragment">[m
[31m-[m
[32m+[m[32m    tools:context=".MainActivity$ForecastFragment">[m
 [m
     <ListView[m
[32m+[m[32m        android:id="@+id/listview_forecast"[m
         android:layout_width="match_parent"[m
[31m-        android:layout_height="match_parent"[m
[31m-        android:id="@+id/listView_forecast"[m
[31m-        android:layout_gravity="center" />[m
[32m+[m[32m        android:layout_height="match_parent" />[m
[32m+[m
 </FrameLayout>[m
[1mdiff --git a/app/src/main/res/menu/forecastfragmen.xml b/app/src/main/res/menu/forecastfragmen.xml[m
[1mdeleted file mode 100644[m
[1mindex 766cc70..0000000[m
[1m--- a/app/src/main/res/menu/forecastfragmen.xml[m
[1m+++ /dev/null[m
[36m@@ -1,13 +0,0 @@[m
[31m-<menu xmlns:android="http://schemas.android.com/apk/res/android"[m
[31m-    xmlns:app="http://schemas.android.com/apk/res-auto"[m
[31m-    xmlns:tools="http://schemas.android.com/tools"[m
[31m-    tools:context=".MainActivity">[m
[31m-[m
[31m-[m
[31m-    <item[m
[31m-        android:id="@+id/action_refresh"[m
[31m-        android:title="@string/action_refresh"[m
[31m-        android:orderInCategory="10"[m
[31m-        app:showAsAction="never" />[m
[31m-[m
[31m-</menu>[m
\ No newline at end of file[m
[1mdiff --git a/app/src/main/res/menu/forecastfragment.xml b/app/src/main/res/menu/forecastfragment.xml[m
[1mnew file mode 100644[m
[1mindex 0000000..50bd125[m
[1m--- /dev/null[m
[1m+++ b/app/src/main/res/menu/forecastfragment.xml[m
[36m@@ -0,0 +1,8 @@[m
[32m+[m[32m<?xml version="1.0" encoding="utf-8"?>[m
[32m+[m
[32m+[m[32m<menu xmlns:android="http://schemas.android.com/apk/res/android"[m
[32m+[m[32m    xmlns:app="http://schemas.android.com/apk/res-auto">[m
[32m+[m[32m    <item android:id="@+id/action_refresh"[m
[32m+[m[32m        android:title="@string/action_refresh"[m
[32m+[m[32m        app:showAsAction="never" />[m
[32m+[m[32m</menu>[m
\ No newline at end of file[m
[1mdiff --git a/app/src/main/res/menu/main.xml b/app/src/main/res/menu/main.xml[m
[1mindex 701f948..b1cb908 100644[m
[1m--- a/app/src/main/res/menu/main.xml[m
[1m+++ b/app/src/main/res/menu/main.xml[m
[36m@@ -1,11 +1,6 @@[m
 <menu xmlns:android="http://schemas.android.com/apk/res/android"[m
     xmlns:app="http://schemas.android.com/apk/res-auto"[m
[31m-    xmlns:tools="http://schemas.android.com/tools"[m
[31m-    tools:context=".MainActivity">[m
[31m-    <item[m
[31m-        android:id="@+id/action_settings"[m
[31m-        android:title="@string/action_settings"[m
[31m-        android:orderInCategory="100"[m
[31m-        app:showAsAction="never" />[m
[31m-[m
[32m+[m[32m    xmlns:tools="http://schemas.android.com/tools" tools:context=".MainActivity">[m
[32m+[m[32m    <item android:id="@+id/action_settings" android:title="@string/action_settings"[m
[32m+[m[32m        android:orderInCategory="100" app:showAsAction="never" />[m
 </menu>[m
[1mdiff --git a/app/src/main/res/values/strings.xml b/app/src/main/res/values/strings.xml[m
[1mindex 8f233dc..94bda40 100644[m
[1m--- a/app/src/main/res/values/strings.xml[m
[1m+++ b/app/src/main/res/values/strings.xml[m
[36m@@ -1,9 +1,21 @@[m
 <?xml version="1.0" encoding="utf-8"?>[m
 <resources>[m
 [m
[32m+[m[32m    <!--[m
[32m+[m[32m         Used in Action Bar, and in AndroidManifest to tell the device the name of this app.[m
[32m+[m[32m         It's to keep this short, so your launcher icon isn't displayed with "The greatest Wea"[m
[32m+[m[32m         or something similar.[m
[32m+[m[32m    -->[m
     <string name="app_name">Sunshine</string>[m
[31m-    <string name="hello_world">Hello world! This is Justin</string>[m
[32m+[m
[32m+[m[32m    <!--[m
[32m+[m[32m         By convention, "action" denotes that this String will be used as the label for an Action,[m
[32m+[m[32m         typically from the action bar.  The ActionBar is limited real estate, so shorter is better.[m
[32m+[m[32m    -->[m
     <string name="action_settings">Settings</string>[m
[31m-    <string name="action_refresh">Refresh</string>[m
[32m+[m
[32m+[m[32m    <!-- Menu label to fetch updated weather info from the server -->[m
[32m+[m[32m    <string name="action_refresh" translatable="false">Refresh</string>[m
[32m+[m[32m    <string name="hello_world">Hello world!</string>[m
 [m
 </resources>[m
