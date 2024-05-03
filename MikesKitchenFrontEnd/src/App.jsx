import { useState } from 'react'
import reactLogo from './assets/react.svg'
import viteLogo from '/vite.svg'
import './App.css'
import Header from './components/Header'
import SearchBar from './components/SearchBar'
import RecipeCardArea from './components/RecipeCardArea'

function App() {
  

  return (
    <div>
      <Header/>
      <SearchBar/>
      <RecipeCardArea/>
    </div>
  )
}

export default App
