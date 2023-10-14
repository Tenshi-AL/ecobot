import React, { useState } from "react";

const SidebarNavigation = ({children}) => {
    return(
        <ul className="metismenu" id="menu">
             {children}
        </ul>
    )
}

export default SidebarNavigation;