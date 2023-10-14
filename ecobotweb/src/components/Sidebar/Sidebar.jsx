import React from "react";
import SidebarHeader from "./SidebarHeader";
import SidebarNavigation from "./SidebarNavigation";
import SidebarNavigationMenuBlock from "./SidebarNavigationMenuBlock";

const Sidebar = () => {
    const menuItems = [{name:'Station', link:'/stations'}]
    // 'Measurment','Measurmed unit','MqttServer','Optimal value'];
    return(
        <aside class="sidebar-wrapper" data-simplebar="true">
            <SidebarHeader title= 'Ecobot UI'/>
            <SidebarNavigation>
                <SidebarNavigationMenuBlock blockName='Tables' menuItems={menuItems}/>
            </SidebarNavigation>
        </aside>
    )
}

export default Sidebar;