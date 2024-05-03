import React from 'react'
import { FaUser } from "react-icons/fa";
import '../styles/Header.css'
import { textDecoration } from '@chakra-ui/react';

const Header = () => {
  return (
    <div className='header'>
      <div>
        <div className='header-menu-title'>Mike's Kitchen</div>
      </div>
      <div className='header-menu'>
        <div className='header-menu-item header-menu-item-selected'>RECIPES</div>
        <div className='header-menu-item'>CALCULATORS</div>
        <div className='header-menu-item'>ABOUT</div>
        <div className='header-menu-item'><FaUser/></div>
      </div>
    </div>
  )
}

export default Header