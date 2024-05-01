import React from 'react'
import { FaSearch } from 'react-icons/fa';
import '../styles/SearchBar.css'

const SearchBar = () => {
  return (
    <div className="search-bar">
      <div className="search-input">
        <input type="text" placeholder="SEARCH" />
        <FaSearch className="search-icon" />
      </div>
    </div>
  )
}

export default SearchBar