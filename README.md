# ASP.NET Core 2.0 with Rider 2018.2 and Visual Studio 2017

This document compares a developer's experience with an ASP.NET Core 2.0 application in two development environments: JetBrains Rider and Microsoft Visual Studio. For the purposes of providing an all-around, detailed comparison, the document walks through the various coding demos available in Scott Allen's [ASP.NET Core Fundamentals](https://app.pluralsight.com/library/courses/aspdotnet-core-fundamentals/table-of-contents) course (as of November 9, 2017) on Pluralsight.

The steps outlined were taken in Visual Studio 2017 15.7.4 (RTM) and various Rider 2018.2 pre-release builds.

<table>
    <tr>
        <th>Step</th>
        <th>Observations: Rider</th>
        <th>Observations: Visual Studio</th>
        <th>Notes/issues/commits</th>
    </tr>
    <tr>
        <td>Creating a new ASP.NET Core Web Application with C# (Empty template)</td>
        <td>
            <ol><li>In <em>New Solution</em> wizard, can't select a directory with the updated <em>Open File</em> dialog; have to enter path to parent directory manually in <em>Solution directory</em> text box; no recent directories available:<br><img class="confluence-embedded-image confluence-thumbnail" width="300" src="./ASP.NET Core 2.0 with Rider 2018.2 and Visual Studio 2017 15.7.4 - ReSharper (Internal) - Confluence_files/new_solution_select_folder.png" data-image-src="/download/attachments/118031306/new_solution_select_folder.png?version=1&amp;modificationDate=1530535980000&amp;api=v2"></li><li>Multimonitor support: Rider opened on display 1, <em>New Solution</em> wizard opened on display 2, then <em>Select Solution Directory</em> (<em>Open File</em>) opened on display 1 again</li><li>Initial IDE layout:<ol><li><em>Solution Explorer</em>'s solution node is collapsed (suboptimal),</li><li><em>Scratches and Consoles</em> node is visible (suboptimal, doesn't relate to the created project);</li><li>Text editor area is empty, contains generic keymap hints<br><img class="confluence-embedded-image confluence-thumbnail" width="300" src="./ASP.NET Core 2.0 with Rider 2018.2 and Visual Studio 2017 15.7.4 - ReSharper (Internal) - Confluence_files/solution_created_rider.png" data-image-src="/download/attachments/118031306/solution_created_rider.png?version=1&amp;modificationDate=1530536936000&amp;api=v2"></li></ol></li></ol>
        </td>
        <td><ol><li><em>Solution Explorer</em>:<ol><li>Expanded to file level (good)</li><li>Text editor area contains ASP.NET Code specific overview page with documentation links; <em>Connected Services</em> and <em>Publish</em> panes are available for navigation<br><img class="confluence-embedded-image confluence-thumbnail" width="300" src="./ASP.NET Core 2.0 with Rider 2018.2 and Visual Studio 2017 15.7.4 - ReSharper (Internal) - Confluence_files/solution_created_visual_studio.png" data-image-src="/download/attachments/118031306/solution_created_visual_studio.png?version=1&amp;modificationDate=1530536904000&amp;api=v2"></li></ol></li><li>Multimonitor support: all UI related to creating a project is opened on a single display</li></ol></td>
        <td>Four</td>
    </tr>
</table>
