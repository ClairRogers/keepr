<template>
  <div class="keepviewmodal">
    <div id="bd-example-modal-lg" class="modal fade bd-example-modal-lg" tabindex="-1" role="dialog"
      aria-labelledby="myLargeModalLabel" aria-hidden="true">
      <div class="modal-dialog modal-lg">
        <div class="modal-content">
          <div class="container-fluid">
            <div class="row">
              <div class="col-6 p-0">
                <img :src="activeKeep.img" class="img-fluid w-100">
              </div>
              <div class="col-6 d-flex flex-column justify-content-between p-0 left-border">
                <div>
                  <h2 class="mt-4 bottom-border pb-2">{{activeKeep.name}}</h2>
                  <p>{{activeKeep.description}}</p>
                </div>
                <div class="card-footer">
                  <small>Last updated 3 mins ago</small>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
  export default {
    name: "keepviewmodal",
    props: [],
    data() {
      return {}
    },
    computed: {
      activeKeep() {
        return this.$store.state.activeKeep
      }
    },
    methods: {},
    components: {}
  }
</script>

<style>
  .modal-content {
    border: 1px solid black;
    background-color: #f4f3f3;
  }

  .bottom-border {
    border-bottom: 5px solid #bfd8d5;
  }

  .left-border {
    border-left: 1px solid #bfd8d5;
  }

  .card-footer {
    background-color: #b1bed5;
    color: white;
  }
</style>