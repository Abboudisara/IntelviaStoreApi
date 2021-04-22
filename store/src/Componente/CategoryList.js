import React from 'react'
import Categorie from './Categorie'

export default function CategoryList() {
    return (
        <div className="row">
<div className="col-md-12">
<div class="jumbotron jumbotron-fluid py-4">
  <div class="container text-center">
    <h1 class="display-4">Categories</h1>
    
  </div>
</div>
</div>

            <div className="col-md-4">
                        <Categorie/>
            </div>

            <div className="col-md-8">
                <div>List of Categories</div>
           </div>
        </div>
    )
}
