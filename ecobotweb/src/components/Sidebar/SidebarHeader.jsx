import React from "react";

const SidebarHeader = ({title}) => {
    return(
        <div class="sidebar-header">
            <div>
                <img src="assets/images/logo-icon-2.png" class="logo-icon" alt="logo icon"/>
            </div>
            <div>
                <h4 class="logo-text">{title}</h4>
            </div>
            <div class="toggle-icon ms-auto">
                <ion-icon name="menu-sharp"></ion-icon>
            </div>
        </div>
    )
}

export default SidebarHeader;