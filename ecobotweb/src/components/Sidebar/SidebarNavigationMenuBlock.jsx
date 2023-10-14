import React from "react";
import { useState } from "react";
import { NavLink } from "react-router-dom";

const SidebarNavigationMenuBlock = ({blockName, menuItems}) => {
    const [active, setActive] = useState(false);
    const onClickHandler = () =>{
        setActive(!active);
    }

    return(
       <>
            <li className="menu-label">{blockName}</li>
                <li className= {active ? 'mm-active':''}>
                <a href="#" class="has-arrow" onClick={onClickHandler}>
                    <div className="parent-icon">
                    <i className="bi bi-handbag"></i>
                    </div>
                    <div className="menu-title">{blockName}</div>
                </a>
                <ul className= {active ? 'mm-collapse mm-show': 'mm-collapse'}>
                    {menuItems&&
                    menuItems.map((item,index)=>(
                        <li key={index}> 
                            <NavLink to={item.link}><a href="#"> <i className="bi bi-circle"></i>{item.name}</a></NavLink>
                        </li>
                    ))
                    }
                </ul>
            </li>
       </>
        
    )
}

export default SidebarNavigationMenuBlock;